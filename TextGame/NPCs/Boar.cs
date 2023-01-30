using System;
using TextGame.Locations;

namespace TextGame
{
    public class Boar : NPC, IEnemy
    {
        public Boar(Location enemyLocation, string enemyName, int enemyHealth)
        {
            Position = enemyLocation;
            Name = enemyName;
            Health = enemyHealth;
        }

        public override void doCommand(string[] command, Player player)
        {
            switch (command[0])
            {
                case "kill":

                    var itemName = player.inventory.Find(item => item.Name == "Sword");

                    if (Position != null && player.Position.Name.Equals(Position.Name) && itemName != null)
                    {
                        Attack(player);
                    }
                    else if (Position != null && player.Position.Name.Equals(Position.Name) && itemName == null)
                    {
                        Console.WriteLine("Killing with your bare hands? A weapon would come in handy.");
                    }
                    break;
                default:
                    break;
            }
        }

        public void Attack(Player p)
        {
            Console.WriteLine($"\nThe boar charges straight at you! Luckily you have your sword, you would not have survived " +
                $"the attack without it. Now that the boar is gone you see another path in front of you to the east.");

            p.Position.PlayerHasInteractedWithLocation = true;

            Position = null;

            p.Position.NpcToBeRemoved = this;
        }
    }
}

