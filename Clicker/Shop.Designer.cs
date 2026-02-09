namespace Clicker
{
    partial class Shop
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnSlot, btnIncome, btnAuto, btnProtect;
        private System.Windows.Forms.Label lblTokens;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTokens = new System.Windows.Forms.Label();
            btnSlot = new System.Windows.Forms.Button();
            btnIncome = new System.Windows.Forms.Button();
            btnAuto = new System.Windows.Forms.Button();
            btnProtect = new System.Windows.Forms.Button();

            lblTokens.AutoSize = true;
            lblTokens.Location = new System.Drawing.Point(20, 20);
            lblTokens.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);

            btnSlot.Text = "+1 Pet Slot (3 tokens)";
            btnSlot.Location = new System.Drawing.Point(20, 60);
            btnSlot.Size = new System.Drawing.Size(300, 40);
            btnSlot.Click += btnSlot_Click;

            btnIncome.Text = "+25% Permanent Income (5 tokens)";
            btnIncome.Location = new System.Drawing.Point(20, 110);
            btnIncome.Size = new System.Drawing.Size(300, 40);
            btnIncome.Click += btnIncome_Click;

            btnAuto.Text = "Auto Clicker x2 (8 tokens)";
            btnAuto.Location = new System.Drawing.Point(20, 160);
            btnAuto.Size = new System.Drawing.Size(300, 40);
            btnAuto.Click += btnAuto_Click;

            btnProtect.Text = "Protect Pets (10 tokens)";
            btnProtect.Location = new System.Drawing.Point(20, 210);
            btnProtect.Size = new System.Drawing.Size(300, 40);
            btnProtect.Click += btnProtect_Click;

            ClientSize = new System.Drawing.Size(350, 300);
            Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblTokens, btnSlot, btnIncome, btnAuto, btnProtect
            });
            Text = "Rebirth Shop";
        }
    }
}