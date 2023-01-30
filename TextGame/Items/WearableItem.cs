using System;
namespace TextGame
{
    public abstract class WearableItem : Item
    {
        public abstract void PutOn(Player p);

        public abstract void RemoveAccessory(Player p);

        public override void doCommand(string[] command, Player p)
        {
            if (IsValidCommand(command))
            {
                switch (command[0])
                {
                    case "wear":
                    case "use":
                        PutOn(p);
                        break;
                    case "remove":
                        RemoveAccessory(p);
                        break;
                    default:
                        break;
                }
            }       
        }
    }
}
