using System;
using System.Linq;

namespace TextGame
{
    public abstract class Item : ICommandable
    {
        public double Weight { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool isTakable { get; set; }
        public bool isEquiped { get; set; }
        public bool isReadable { get; set; }

        public abstract void doCommand(string[] command, Player player);

        public bool IsValidCommand(string[] command) => command.Length > 1 && command[1].Equals(Name.ToLower());

        public void MakeItemTakable(Player p, string nameOfItem)
        {
            var items = from n in Game.allItems
                        where n.Name == nameOfItem
                        select n;

            foreach (var item in items)
            {
                item.isTakable = true;
            }
        }

        public void PrintYourself()
        {
            if (!isEquiped)
            {
                Console.WriteLine($"{Name}, {Weight} kg");
            }
            else
            {
                Console.WriteLine($"{Name}, {Weight} kg (EQUIPED)");
            }
            
        }
        
    }
}
