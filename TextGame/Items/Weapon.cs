using System;
namespace TextGame
{
    public abstract class Weapon : Item
    {
        public int Damage { get; set; }

        public override void doCommand(string[] command, Player p)
        {
            if (IsValidCommand(command))
            {
                switch (command[0])
                {
                    case "use":
                        Use(p, Name);
                        break;
                    default:
                        break;
                }
            }
        }

        protected abstract void Use(Player p, string name);
    }
}
