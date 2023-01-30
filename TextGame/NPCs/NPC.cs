using System;
using TextGame.Locations;

namespace TextGame
{
    public abstract class NPC : ICommandable
    {
        public Location Position { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }

        public void describeYourself()
        {
            Console.WriteLine(Name);
        }

        public abstract void doCommand(String[] inCommand, Player player);
    }
}
