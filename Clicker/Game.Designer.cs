namespace Clicker
{
    partial class Game
    {
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.Button btnClick, btnUpgradeClick, btnUpgradeAuto, btnRebirth, btnShop, btnPets, btnEggs;
        public System.Windows.Forms.Label lblCoins, lblStats, lblMessage;
        public System.Windows.Forms.Timer Timer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnClick = new System.Windows.Forms.Button();
            btnUpgradeClick = new System.Windows.Forms.Button();
            btnUpgradeAuto = new System.Windows.Forms.Button();
            btnRebirth = new System.Windows.Forms.Button();
            btnShop = new System.Windows.Forms.Button();
            btnPets = new System.Windows.Forms.Button();
            btnEggs = new System.Windows.Forms.Button();
            lblCoins = new System.Windows.Forms.Label();
            lblStats = new System.Windows.Forms.Label();
            lblMessage = new System.Windows.Forms.Label();
            Timer = new System.Windows.Forms.Timer(components);

            btnClick.Text = "CLICK!";
            btnClick.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold);
            btnClick.Location = new System.Drawing.Point(20, 20);
            btnClick.Size = new System.Drawing.Size(400, 300);
            btnClick.Click += btnClick_Click;

            btnUpgradeClick.Location = new System.Drawing.Point(450, 20);
            btnUpgradeClick.Size = new System.Drawing.Size(200, 40);
            btnUpgradeClick.Click += btnUpgradeClick_Click;

            btnUpgradeAuto.Location = new System.Drawing.Point(450, 70);
            btnUpgradeAuto.Size = new System.Drawing.Size(200, 40);
            btnUpgradeAuto.Click += btnUpgradeAuto_Click;

            btnRebirth.Location = new System.Drawing.Point(450, 120);
            btnRebirth.Size = new System.Drawing.Size(200, 40);
            btnRebirth.Click += btnRebirth_Click;

            btnShop.Location = new System.Drawing.Point(450, 170);
            btnShop.Size = new System.Drawing.Size(200, 40);
            btnShop.Text = "Rebirth Shop";
            btnShop.Click += btnShop_Click;

            btnPets.Location = new System.Drawing.Point(450, 220);
            btnPets.Size = new System.Drawing.Size(200, 40);
            btnPets.Text = "Pets";
            btnPets.Click += btnPets_Click;

            btnEggs.Location = new System.Drawing.Point(450, 270);
            btnEggs.Size = new System.Drawing.Size(200, 40);
            btnEggs.Text = "Eggs";
            btnEggs.Click += btnEggs_Click;

            lblCoins.Location = new System.Drawing.Point(20, 330);
            lblCoins.AutoSize = true;
            lblCoins.Font = new System.Drawing.Font("Arial", 14F);

            lblStats.Location = new System.Drawing.Point(20, 360);
            lblStats.AutoSize = true;
            lblStats.Size = new System.Drawing.Size(400, 200);

            lblMessage.Location = new System.Drawing.Point(20, 500);
            lblMessage.AutoSize = true;
            lblMessage.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);

            Timer.Interval = 1000;
            Timer.Tick += Timer_Tick;

            ClientSize = new System.Drawing.Size(700, 600);
            Controls.AddRange(new System.Windows.Forms.Control[]
            {
                btnClick, btnUpgradeClick, btnUpgradeAuto, btnRebirth,
                btnShop, btnPets, btnEggs, lblCoins, lblStats, lblMessage
            });
            Text = "Clicker Game";
        }
    }
}