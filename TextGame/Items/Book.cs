using System;
namespace TextGame
{
    public class Book : Tool
    {
        public Book(double inWeight, string inName, int inPrice)
        {
            Weight = inWeight;
            Name = inName;
            Price = inPrice;
            isReadable = true;
        }

        public override void Use(Player p, string itemName)
        {
            if (p.Position.Name.Equals("mountain"))
            {
                Console.WriteLine("\nAs you unveil the book, the mountain seems to react to its prescence. \n" +
                    "You read a passage from it. The mountain explodes and you are lunged to heaven where God grants you eternal life " +
                    "and sends you back to earth to rule as a demi-God.\n");
                p.PlayerHasCompletedTheGame = true;
            }
            else
            {
                Console.WriteLine("\nYou read the book and learn about the history of Titanic.");
            } 
        }
    }
}
