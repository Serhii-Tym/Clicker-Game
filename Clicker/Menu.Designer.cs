namespace Clicker
{
    partial class Menu
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnNewGame = new System.Windows.Forms.Button();
            btnContinue = new System.Windows.Forms.Button();
            lblTitle = new System.Windows.Forms.Label();
            SuspendLayout();

            lblTitle.Text = "CLICKER GAME";
            lblTitle.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new System.Drawing.Point(250, 60);

            btnNewGame.Text = "New Game";
            btnNewGame.Location = new System.Drawing.Point(300, 160);
            btnNewGame.Size = new System.Drawing.Size(200, 50);
            btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);

            btnContinue.Text = "Continue";
            btnContinue.Location = new System.Drawing.Point(300, 230);
            btnContinue.Size = new System.Drawing.Size(200, 50);
            btnContinue.Click += new System.EventHandler(this.btnContinue_Click);

            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(lblTitle);
            Controls.Add(btnNewGame);
            Controls.Add(btnContinue);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Menu";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}