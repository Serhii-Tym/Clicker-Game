using System;
using System.Windows.Forms;

namespace Clicker
{
    public partial class EggForm : Form
    {
        Game game;
        Button btnBasic, btnAdvanced, btnMythic;
        Label lblResult;

        public EggForm(Game g)
        {
            game = g;
            InitializeComponent();
        }

        void InitializeComponent()
        {
            Text = "Egg Shop";
            Size = new System.Drawing.Size(400, 350);

            btnBasic = new Button();
            btnBasic.Text = "Basic Egg (100)";
            btnBasic.Location = new System.Drawing.Point(20, 20);
            btnBasic.Size = new System.Drawing.Size(340, 50);
            btnBasic.Click += (s, e) => BuyEgg(EggType.Basic);

            btnAdvanced = new Button();
            btnAdvanced.Text = "Advanced Egg (500)";
            btnAdvanced.Location = new System.Drawing.Point(20, 80);
            btnAdvanced.Size = new System.Drawing.Size(340, 50);
            btnAdvanced.Click += (s, e) => BuyEgg(EggType.Advanced);

            btnMythic = new Button();
            btnMythic.Text = "Mythic Egg (2000)";
            btnMythic.Location = new System.Drawing.Point(20, 140);
            btnMythic.Size = new System.Drawing.Size(340, 50);
            btnMythic.Click += (s, e) => BuyEgg(EggType.Mythic);

            lblResult = new Label();
            lblResult.Location = new System.Drawing.Point(20, 220);
            lblResult.Size = new System.Drawing.Size(340, 80);
            lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            Controls.Add(btnBasic);
            Controls.Add(btnAdvanced);
            Controls.Add(btnMythic);
            Controls.Add(lblResult);
        }

        public void BuyEgg(EggType type)
        {
            Egg egg = new Egg(type);
            if (game.coins < egg.Cost)
            {
                lblResult.Text = "Not enough coins!";
                return;
            }

            game.coins -= egg.Cost;
            Pet pet = egg.Open(game.rnd);
            game.petInventory.Add(pet);
            lblResult.Text = $"Got: {pet.Name}\nRarity: {pet.Rarity}";
        }
    }
}