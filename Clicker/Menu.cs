using System;
using System.Windows.Forms;

namespace Clicker
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        void StartGame()
        {
            Game g = new Game();
            g.Show();
            Hide();
            g.FormClosed += (s, a) => Close();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();
            StartGame();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            StartGame();
        }
    }
}