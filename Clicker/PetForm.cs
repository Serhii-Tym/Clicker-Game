using System;
using System.Linq;
using System.Windows.Forms;

namespace Clicker
{
    public partial class PetForm : Form
    {
        Game game;
        ListBox lstInventory;
        ListBox lstActive;
        Button btnActivate;
        Button btnDeactivate;
        Button btnFusion;
        Label lblInfo;

        public PetForm(Game g)
        {
            game = g;
            InitializeComponent();
            RefreshLists();
        }

        void InitializeComponent()
        {
            Text = "Pets";
            Size = new System.Drawing.Size(600, 500);

            lstInventory = new ListBox();
            lstInventory.Location = new System.Drawing.Point(20, 40);
            lstInventory.Size = new System.Drawing.Size(250, 300);

            lstActive = new ListBox();
            lstActive.Location = new System.Drawing.Point(300, 40);
            lstActive.Size = new System.Drawing.Size(250, 150);

            btnActivate = new Button();
            btnActivate.Text = "Activate ->";
            btnActivate.Location = new System.Drawing.Point(20, 350);
            btnActivate.Click += BtnActivate_Click;

            btnDeactivate = new Button();
            btnDeactivate.Text = "<- Deactivate";
            btnDeactivate.Location = new System.Drawing.Point(300, 200);
            btnDeactivate.Click += BtnDeactivate_Click;

            btnFusion = new Button();
            btnFusion.Text = "Fusion 3 Same Pets";
            btnFusion.Location = new System.Drawing.Point(20, 400);
            btnFusion.Size = new System.Drawing.Size(200, 30);
            btnFusion.Click += BtnFusion_Click;

            lblInfo = new Label();
            lblInfo.Location = new System.Drawing.Point(300, 250);
            lblInfo.Size = new System.Drawing.Size(250, 150);
            lblInfo.Text = $"Slots: {game.activePets.Count}/{game.maxPetSlots}";

            Controls.Add(lstInventory);
            Controls.Add(lstActive);
            Controls.Add(btnActivate);
            Controls.Add(btnDeactivate);
            Controls.Add(btnFusion);
            Controls.Add(lblInfo);

            Label lblInv = new Label();
            lblInv.Text = "Inventory:";
            lblInv.Location = new System.Drawing.Point(20, 20);
            Controls.Add(lblInv);

            Label lblAct = new Label();
            lblAct.Text = "Active:";
            lblAct.Location = new System.Drawing.Point(300, 20);
            Controls.Add(lblAct);
        }

        void RefreshLists()
        {
            lstInventory.Items.Clear();
            foreach (var pet in game.petInventory)
                lstInventory.Items.Add(pet);

            lstActive.Items.Clear();
            foreach (var pet in game.activePets)
                lstActive.Items.Add(pet);

            lblInfo.Text = $"Slots: {game.activePets.Count}/{game.maxPetSlots}\n\n" +
                $"Click Bonus: x{game.GetPetClickBonus():0.00}\n" +
                $"Auto Bonus: x{game.GetPetAutoBonus():0.00}\n" +
                $"Income Multiplier: x{game.GetPetIncomeMultiplier():0.00}";
        }

        void BtnActivate_Click(object sender, EventArgs e)
        {
            if (lstInventory.SelectedItem == null) return;
            if (game.activePets.Count >= game.maxPetSlots) return;

            Pet selected = (Pet)lstInventory.SelectedItem;
            game.petInventory.Remove(selected);
            game.activePets.Add(selected);
            RefreshLists();
        }

        void BtnDeactivate_Click(object sender, EventArgs e)
        {
            if (lstActive.SelectedItem == null) return;

            Pet selected = (Pet)lstActive.SelectedItem;
            game.activePets.Remove(selected);
            game.petInventory.Add(selected);
            RefreshLists();
        }

        void BtnFusion_Click(object sender, EventArgs e)
        {
            var groups = game.petInventory.GroupBy(p => new { p.Name, p.Rarity }).Where(g => g.Count() >= 3);
            if (!groups.Any())
            {
                MessageBox.Show("Need 3 identical pets for fusion!");
                return;
            }

            var group = groups.First();
            var petsToRemove = group.Take(3).ToList();

            foreach (var p in petsToRemove)
                game.petInventory.Remove(p);

            Rarity newRarity = group.Key.Rarity;
            if (newRarity == Rarity.Common) newRarity = Rarity.Rare;
            else if (newRarity == Rarity.Rare) newRarity = Rarity.Epic;
            else if (newRarity == Rarity.Epic) newRarity = Rarity.Legendary;

            Pet newPet = new Pet(group.Key.Name, newRarity);
            game.petInventory.Add(newPet);

            MessageBox.Show($"Got: {newPet}!");
            RefreshLists();
        }
    }
}