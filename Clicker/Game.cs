using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Clicker
{
    public partial class Game : Form
    {
        public double coins;
        public double clickPower;
        public double autoClickPower;
        public double upgradeCost;
        public double autoUpgradeCost;

        public int rebirthCount;
        public int rebirthTokens;
        public double rebirthMultiplier;

        public List<Pet> petInventory;
        public List<Pet> activePets;
        public int maxPetSlots;
        public bool petsProtected;

        public double permanentIncomeBonus;
        public double autoClickMultiplier;

        public Random rnd;

        public Game()
        {
            InitializeComponent();
            rnd = new Random();
            LoadGame();
            Timer.Start();
            UpdateUI();
        }

        void LoadGame()
        {
            coins = Properties.Settings.Default.coins;
            clickPower = Properties.Settings.Default.clickPower;
            if (clickPower < 1) clickPower = 1;
            autoClickPower = Properties.Settings.Default.autoClickPower;
            upgradeCost = Properties.Settings.Default.upgradeCost;
            if (upgradeCost < 10) upgradeCost = 10;
            autoUpgradeCost = Properties.Settings.Default.autoUpgradeCost;
            if (autoUpgradeCost < 50) autoUpgradeCost = 50;

            rebirthCount = Properties.Settings.Default.rebirthCount;
            rebirthTokens = Properties.Settings.Default.rebirthTokens;
            rebirthMultiplier = Properties.Settings.Default.rebirthMultiplier;
            if (rebirthMultiplier < 1) rebirthMultiplier = 1;

            maxPetSlots = Properties.Settings.Default.maxPetSlots;
            if (maxPetSlots < 3) maxPetSlots = 3;
            petsProtected = Properties.Settings.Default.petsProtected;
            permanentIncomeBonus = Properties.Settings.Default.permanentIncomeBonus;
            autoClickMultiplier = Properties.Settings.Default.autoClickMultiplier;
            if (autoClickMultiplier < 1) autoClickMultiplier = 1;

            petInventory = LoadPetList("petInventory");
            activePets = LoadPetList("activePets");
        }

        void SaveGame()
        {
            Properties.Settings.Default.coins = coins;
            Properties.Settings.Default.clickPower = clickPower;
            Properties.Settings.Default.autoClickPower = autoClickPower;
            Properties.Settings.Default.upgradeCost = upgradeCost;
            Properties.Settings.Default.autoUpgradeCost = autoUpgradeCost;

            Properties.Settings.Default.rebirthCount = rebirthCount;
            Properties.Settings.Default.rebirthTokens = rebirthTokens;
            Properties.Settings.Default.rebirthMultiplier = rebirthMultiplier;

            Properties.Settings.Default.maxPetSlots = maxPetSlots;
            Properties.Settings.Default.petsProtected = petsProtected;
            Properties.Settings.Default.permanentIncomeBonus = permanentIncomeBonus;
            Properties.Settings.Default.autoClickMultiplier = autoClickMultiplier;

            SavePetList("petInventory", petInventory);
            SavePetList("activePets", activePets);

            Properties.Settings.Default.Save();
        }

        List<Pet> LoadPetList(string key)
        {
            var list = new List<Pet>();
            string data = Properties.Settings.Default[key] as string;
            if (string.IsNullOrEmpty(data)) return list;

            string[] pets = data.Split('|');
            foreach (string p in pets)
            {
                if (string.IsNullOrEmpty(p)) continue;
                string[] parts = p.Split(',');
                if (parts.Length >= 2)
                {
                    list.Add(new Pet(parts[0], (Rarity)Enum.Parse(typeof(Rarity), parts[1])));
                }
            }
            return list;
        }

        void SavePetList(string key, List<Pet> list)
        {
            string data = string.Join("|", list.Select(p => $"{p.Name},{p.Rarity}"));
            Properties.Settings.Default[key] = data;
        }

        public double GetPetClickBonus()
        {
            double bonus = 1.0;
            foreach (var pet in activePets)
                bonus += pet.ClickBonus;
            return bonus;
        }

        public double GetPetAutoBonus()
        {
            double bonus = 1.0;
            foreach (var pet in activePets)
                bonus += pet.AutoBonus;
            return bonus;
        }

        public double GetPetIncomeMultiplier()
        {
            double mult = 1.0;
            foreach (var pet in activePets)
                mult *= pet.IncomeMultiplier;
            return mult;
        }

        void UpdateUI()
        {
            lblCoins.Text = $"Coins: {FormatNumber(coins)}";
            lblStats.Text =
                $"Click: {FormatNumber(clickPower)}\n" +
                $"Auto: {FormatNumber(GetAutoPerSecond())}/s\n\n" +
                $"Rebirths: {rebirthCount}\n" +
                $"Tokens: {rebirthTokens}\n" +
                $"Multiplier: x{rebirthMultiplier}\n\n" +
                $"Active Pets: {activePets.Count}/{maxPetSlots}\n" +
                $"Inventory: {petInventory.Count}";

            btnUpgradeClick.Text = $"Upgrade Click ({FormatNumber(upgradeCost)})";
            btnUpgradeAuto.Text = $"Upgrade Auto ({FormatNumber(autoUpgradeCost)})";
            btnRebirth.Text = $"Rebirth ({FormatNumber(GetRebirthCost())})";
        }

        string FormatNumber(double num)
        {
            if (num >= 1000000) return (num / 1000000).ToString("0.0") + "M";
            if (num >= 1000) return (num / 1000).ToString("0.0") + "K";
            return num.ToString("0");
        }

        double GetAutoPerSecond()
        {
            return autoClickPower * GetPetAutoBonus() * rebirthMultiplier * GetPetIncomeMultiplier() * (1 + permanentIncomeBonus) * autoClickMultiplier;
        }

        double GetRebirthCost()
        {
            return 1000 * Math.Pow(2, rebirthCount);
        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            double gain = clickPower * GetPetClickBonus() * rebirthMultiplier * GetPetIncomeMultiplier() * (1 + permanentIncomeBonus);
            coins += gain;
            UpdateUI();
        }

        private void btnUpgradeClick_Click(object sender, EventArgs e)
        {
            if (coins < upgradeCost) return;
            coins -= upgradeCost;
            clickPower *= 1.5;
            upgradeCost *= 1.6;
            UpdateUI();
        }

        private void btnUpgradeAuto_Click(object sender, EventArgs e)
        {
            if (coins < autoUpgradeCost) return;
            coins -= autoUpgradeCost;
            autoClickPower += 1;
            autoUpgradeCost *= 1.7;
            UpdateUI();
        }

        private void btnRebirth_Click(object sender, EventArgs e)
        {
            double cost = GetRebirthCost();
            if (coins < cost) return;

            rebirthCount++;
            rebirthTokens += 1 + rebirthCount / 3;
            rebirthMultiplier = 1 + rebirthCount * 0.5;

            coins = 0;
            clickPower = 1;
            autoClickPower = 0;
            upgradeCost = 10;
            autoUpgradeCost = 50;

            if (!petsProtected)
            {
                petInventory.Clear();
                activePets.Clear();
            }

            lblMessage.Text = $"+{1 + rebirthCount / 3} TOKENS!";
            lblMessage.ForeColor = Color.Gold;
            UpdateUI();
        }

        private void btnShop_Click(object sender, EventArgs e)
        {
            Shop s = new Shop(this);
            s.ShowDialog();
            UpdateUI();
        }

        private void btnPets_Click(object sender, EventArgs e)
        {
            PetForm p = new PetForm(this);
            p.ShowDialog();
            UpdateUI();
        }

        private void btnEggs_Click(object sender, EventArgs e)
        {
            EggForm egg = new EggForm(this);
            egg.ShowDialog();
            UpdateUI();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            coins += GetAutoPerSecond();
            UpdateUI();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveGame();
            base.OnFormClosing(e);
        }
    }
}