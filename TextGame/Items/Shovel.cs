using System;
namespace TextGame
{
    public class Shovel : Tool
    {
        public Shovel(double inWeight, string inName, int inPrice)
        {
            Weight = inWeight;
            Name = inName;
            Price = inPrice;
            isReadable = false;
        }

        public override void Use(Player player, string itemName)
        {
            Item itemToRemove = null;
            foreach (var item in player.Position.itemsInLocation)
            {
                if (item is Coin)
                {
                    player.inventory.Add(item);
                    Console.WriteLine($"\nYou dug up a {item.Name}");
                    itemToRemove = item;
                }
            }
            player.Position.RemoveItemFromArea(itemToRemove);
        }

    }
}
