using System;
namespace TextGame
{
    public class Coin : Tool
    {
        public Coin(double inWeight, string inName, int inPrice)
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
                Console.WriteLine("There's nothing to do with the coin.");
            }
        }
    }
}
