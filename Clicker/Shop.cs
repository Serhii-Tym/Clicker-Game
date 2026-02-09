using System;
using System.Windows.Forms;

namespace Clicker
{
    public partial class Shop : Form
    {
        Game game;

        public Shop(Game g)
        {
            InitializeComponent();
            game = g;
            UpdateUI();
        }

        void UpdateUI()
        {
            lblTokens.Text = $"Tokens: {game.rebirthTokens}";
            btnSlot.Enabled = game.rebirthTokens >= 3;
            btnIncome.Enabled = game.rebirthTokens >= 5;
            btnAuto.Enabled = game.rebirthTokens >= 8;
            btnProtect.Enabled = game.rebirthTokens >= 10 && !game.petsProtected;
        }

        private void btnSlot_Click(object sender, EventArgs e)
        {
            if (game.rebirthTokens < 3) return;
            game.rebirthTokens -= 3;
            game.maxPetSlots++;
            UpdateUI();
        }

        private void btnIncome_Click(object sender, EventArgs e)
        {
            if (game.rebirthTokens < 5) return;
            game.rebirthTokens -= 5;
            game.permanentIncomeBonus += 0.25;
            UpdateUI();
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            if (game.rebirthTokens < 8) return;
            game.rebirthTokens -= 8;
            game.autoClickMultiplier *= 2;
            UpdateUI();
        }

        private void btnProtect_Click(object sender, EventArgs e)
        {
            if (game.rebirthTokens < 10) return;
            game.rebirthTokens -= 10;
            game.petsProtected = true;
            UpdateUI();
        }
    }
}