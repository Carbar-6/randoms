using System;
using System.Collections.Generic;
using System.Linq;

namespace TextGame
{
    public class ProteinShake : Tool
    {
        public ProteinShake(double inWeight, string inName, int inPrice)
        {
            Weight = inWeight;
            Name = inName;
            Price = inPrice;
            isTakable = true;
            isReadable = false;
        }

        public override void Use(Player p, string itemName)
        {
            if (p.inventory.Contains(this))
            {
                Console.WriteLine($"\nYou consume the {Name}. You feel stronger, like you could pull a sharp object from a stone without" +
    $"breaking a sweat.");

                MakeItemTakable(p, "Sword");
                p.RemoveItemFromInventory(this);
            }
        }
    }
}
