using System;
namespace TextGame
{
    public class Flashlight : Tool
    {
        public Flashlight(double inWeight, string inName, int inPrice)
        {
            Weight = inWeight;
            Name = inName;
            Price = inPrice;
            isReadable = false;
        }

        public override void Use(Player p, string itemName)
        {
            if (p.inventory.Contains(this))
            {
                Console.WriteLine($"You use the {itemName}. Nothing special is revealed.");
            }           
        }
    }
}
