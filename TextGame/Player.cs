using System;
using System.Collections.Generic;
using TextGame.Locations;

namespace TextGame
{
    public class Player
    {
        public string Name { get; set; }
        public Location Position { get; set; }
        public int Gold { get; set; }
        public int Health { get; set; }
        public bool HasMovedToNewLocation { get; set; }
        public Item ItemInEquipmentToBeRemoved { get; set; }
        public Item ItemToAddToAllCommandableObject { get; set; }
        public bool PlayerHasCompletedTheGame { get; set; }

        public List<Item> inventory = new List<Item>();
        public List<Item> equipedItems = new List<Item>();

        public Player(int inGold, int startHealth)
        {
            Gold = inGold;
            Health = startHealth;
        }

        public void moveTo(Location positionToMoveTo)
        {
            positionToMoveTo.NumberOfVisits++;
            Position = positionToMoveTo;
            HasMovedToNewLocation = true;

            if (Position.PlayerHasInteractedWithLocation || Position.NumberOfVisits > 1)
            {
                Position.UpdateDescription(Position);
            }
        }

        public void AddItemToInventory(Item item) => inventory.Add(item);

        public void RemoveItemFromInventory(Item item)
        {
            inventory.Remove(item);
            ItemInEquipmentToBeRemoved = null;
        }

        public void giveItem(Item item)
        {
            Console.WriteLine("You give stuff");
        }

    }
}
