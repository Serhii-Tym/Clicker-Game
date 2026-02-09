using System;

namespace Clicker
{
    public enum Rarity { Common, Rare, Epic, Legendary }

    public class Pet
    {
        public string Name { get; set; }
        public Rarity Rarity { get; set; }
        public double ClickBonus { get; set; }
        public double AutoBonus { get; set; }
        public double IncomeMultiplier { get; set; }
        public string SpecialEffect { get; set; }

        public Pet(string name, Rarity rarity)
        {
            Name = name;
            Rarity = rarity;
            SetStats();
        }

        void SetStats()
        {
            switch (Rarity)
            {
                case Rarity.Common:
                    ClickBonus = 0.05;
                    AutoBonus = 0;
                    IncomeMultiplier = 1.0;
                    break;
                case Rarity.Rare:
                    ClickBonus = 0.15;
                    AutoBonus = 0.10;
                    IncomeMultiplier = 1.0;
                    break;
                case Rarity.Epic:
                    ClickBonus = 0.30;
                    AutoBonus = 0.25;
                    IncomeMultiplier = 1.40;
                    break;
                case Rarity.Legendary:
                    ClickBonus = 0.50;
                    AutoBonus = 0.50;
                    IncomeMultiplier = 2.0;
                    SpecialEffect = "Golden Touch";
                    break;
            }
        }

        public override string ToString()
        {
            return $"{Name} [{Rarity}]";
        }
    }
}