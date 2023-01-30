using System;
namespace TextGame
{
    public class Robe : WearableItem
    {
        public Robe(double inWeight, string inName, int inPrice)
        {
            Weight = inWeight;
            Name = inName;
            Price = inPrice;
            isReadable = false;
        }

        public override void PutOn(Player p)
        {
            Console.WriteLine($"\nYou put on the {Name}");
            p.equipedItems.Add(this);
            isEquiped = true;
        }

        public override void RemoveAccessory(Player p)
        {
            Console.WriteLine($"\nYou removed the {Name}");
            p.equipedItems.Remove(this);
            isEquiped = false;
            
        }
    }
}
