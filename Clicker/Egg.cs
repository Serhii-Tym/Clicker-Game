using System;
using System.Collections.Generic;

namespace Clicker
{
    public enum EggType { Basic, Advanced, Mythic }

    public class Egg
    {
        public EggType Type { get; set; }
        public int Cost { get; set; }
        public string Name { get; set; }

        public Egg(EggType type)
        {
            Type = type;
            switch (type)
            {
                case EggType.Basic:
                    Name = "Basic Egg";
                    Cost = 100;
                    break;
                case EggType.Advanced:
                    Name = "Advanced Egg";
                    Cost = 500;
                    break;
                case EggType.Mythic:
                    Name = "Mythic Egg";
                    Cost = 2000;
                    break;
            }
        }

        public Pet Open(Random rnd)
        {
            string[] commonNames = { "Cat", "Dog", "Rabbit", "Hamster" };
            string[] rareNames = { "Fox", "Wolf", "Eagle" };
            string[] epicNames = { "Griffin", "Phoenix", "Whelp" };
            string[] legendaryNames = { "Dragon", "God", "Titan" };

            int roll = rnd.Next(100);
            Rarity rarity;
            string name;

            switch (Type)
            {
                case EggType.Basic:
                    if (roll < 70) { rarity = Rarity.Common; name = commonNames[rnd.Next(commonNames.Length)]; }
                    else if (roll < 95) { rarity = Rarity.Rare; name = rareNames[rnd.Next(rareNames.Length)]; }
                    else { rarity = Rarity.Epic; name = epicNames[rnd.Next(epicNames.Length)]; }
                    break;
                case EggType.Advanced:
                    if (roll < 50) { rarity = Rarity.Rare; name = rareNames[rnd.Next(rareNames.Length)]; }
                    else if (roll < 85) { rarity = Rarity.Epic; name = epicNames[rnd.Next(epicNames.Length)]; }
                    else { rarity = Rarity.Legendary; name = legendaryNames[rnd.Next(legendaryNames.Length)]; }
                    break;
                case EggType.Mythic:
                    if (roll < 70) { rarity = Rarity.Epic; name = epicNames[rnd.Next(epicNames.Length)]; }
                    else { rarity = Rarity.Legendary; name = legendaryNames[rnd.Next(legendaryNames.Length)]; }
                    break;
                default:
                    rarity = Rarity.Common;
                    name = commonNames[0];
                    break;
            }

            return new Pet(name, rarity);
        }
    }
}