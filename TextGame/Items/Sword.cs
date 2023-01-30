using System;
namespace TextGame
{
    public class Sword : Weapon
    {
        public Sword(double inWeight, string inName, int inPrice)
        {
            Weight = inWeight;
            Name = inName;
            Price = inPrice;
            isReadable = false;
        }

        protected override void Use(Player p, string name)
        {
            if (p.inventory.Contains(this))
            {
                Console.WriteLine($"You use the {Name}");
            }
        }
    }
}
