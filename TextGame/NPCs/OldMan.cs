using System;
using TextGame.Locations;

namespace TextGame
{
    public class OldMan : NPC, IFriend
    {
        public OldMan(Location friendLocation, string friendName, int friendHealth)
        {
            Position = friendLocation;
            Name = friendName;
            Health = friendHealth;
        }


        public override void doCommand(string[] command, Player player)
        {
            if (command.Length > 1)
            {
                switch (command[0])
                {
                    case "give":
                        bool hasCoin = false;
                        if (player.Position.Name.Equals(Position.Name) && command[1].ToLower().Equals("coin") || player.Position.Name.Equals(Position.Name) && command[1].ToLower().Equals("coins"))
                        {
                            foreach (var item in player.inventory)
                            {
                                if (item is Coin)
                                {
                                    hasCoin = true;
                                }
                            }
                            if (hasCoin)
                            {
                                InteractWith(player);
                            }
                        }
                        break;
                    case "talk":
                        if (player.Position.Name.Equals(Position.Name) && command.Length > 2 && command[1].ToLower().Equals("to") && command[2].ToLower().Equals("man"))
                        {
                            Console.WriteLine("The old man stutters: 'C-c-can't talk... t-t-to poor.'");
                        }
                        else if (player.Position.Name.Equals(Position.Name) && command.Length > 2 && command[1].ToLower().Equals("to") && command[2].ToLower().Equals("man") && player.Position.PlayerHasInteractedWithLocation)
                        {
                            Console.WriteLine("The old man repeats himself: 'Seek the altar on the mountain summit, and place this book thereupon. You will" +
                                " then find your true purpose!'");
                        }
                        break;
                    default:
                        break;
                }
            } 
        }

        public void InteractWith(Player p)
        {
            Console.WriteLine("\nThe man's bushy eyebrows are raised and you can see the wisdom in his aged eyes. " +
             "He tells you '{0}, go to the top of the altar on the mountain summit, and place this book thereupon. You will" +
             " then find your true purpose!'. You got a strange, leatherbound book from the beggar.", p.Name);

            Item book = new Book(0.9, "Book", 20);
            p.inventory.Add(book);
            p.ItemToAddToAllCommandableObject = book;

            foreach (var item in p.inventory)
            {
                if (item.Name.Equals("Coin"))
                {
                    p.ItemInEquipmentToBeRemoved = item;
                }
            }

            p.Position.PlayerHasInteractedWithLocation = true;   
        }
    }
}
