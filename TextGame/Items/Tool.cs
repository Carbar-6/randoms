using System;
namespace TextGame
{
    public abstract class Tool : Item
    {
        public override void doCommand(string[] command, Player p)
        {
            if (IsValidCommand(command))
            {
                switch (command[0])
                {
                    case "use":
                        Use(p, Name);
                        break;
                    case "read":
                        if (isReadable == true)
                        {
                            Use(p, Name);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public abstract void Use(Player p, string itemName);
    }
}
