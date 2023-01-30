using System;
namespace TextGame
{
    public class Interactions : ICommandable
    {
        public void doCommand(string[] command, Player player)
        {
            switch (command[0])
            {
                case "help":
                    Console.WriteLine("\nYou can move around by typing north/south/west/east. " +
                $"You will have to learn more commands as you play the game!");
                    break;
                case "look":
                    if (player.Position.PlayerHasInteractedWithLocation)
                    {
                        player.Position.UpdateDescription(player.Position);
                    }
                    player.Position.describeYourself();
                    break;
                case "items":
                    foreach (var item in player.inventory)
                    {
                        item.PrintYourself();
                    }
                    break;
                case "take":
                    if (command.Length > 1)
                    {
                        TakeItem(command[1], player);
                    }
                    break;
                case "pick":
                    if (command[1].Equals("up"))
                    {
                        TakeItem(command[2], player);
                    }
                    break;
                default:
                    break;
            }
        }

        private void TakeItem(String itemToTake, Player player)
        {
            Item itemToRemove = null;
            foreach (var item in player.Position.itemsInLocation)
            {
                if (itemToTake.Equals(item.Name.ToLower()) && item.isTakable)
                {
                    player.inventory.Add(item);
                    Console.WriteLine($"\nYou picked up {item.Name}");
                    itemToRemove = item;
                    player.Position.PlayerHasInteractedWithLocation = true;
                }
            }
            player.Position.RemoveItemFromArea(itemToRemove);
        }
    }
}
