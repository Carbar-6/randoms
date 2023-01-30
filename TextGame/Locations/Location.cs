using System;
using System.Collections.Generic;

namespace TextGame.Locations
{
    public abstract class Location : ICommandable
    {
        public string Name { get; set; }
        public Location[] Paths { get; set; }
        public int NumberOfVisits { get; set; }
        public NPC NpcToBeRemoved { get; set; }
        public bool PlayerHasInteractedWithLocation { get; set; }
        public string[] LocationDescriptions;

        public List<Item> itemsInLocation { get; set; }
        public List<NPC> NPCsInLocation { get; set; }

        public abstract void doCommand(string[] inCommand, Player player);

        public void AddNeigbouringAreas(Location locationToAdd, int path) => Paths[path] = locationToAdd;

        public void AddItemToArea(Item i) => itemsInLocation.Add(i);

        public void RemoveItemFromArea(Item i) => itemsInLocation.Remove(i);

        public void AddNPCToLocation(NPC npc) => NPCsInLocation.Add(npc);

        public void RemoveNPCFromArea(NPC npc) => NPCsInLocation.Remove(npc);

        public void describeYourself() => Console.WriteLine(LocationDescriptions[0]);

        public void UpdateDescription(Location location)
        {
            if (location.PlayerHasInteractedWithLocation)
            {
                LocationDescriptions[0] = LocationDescriptions[2];
            }
            else if (location.NumberOfVisits > 0)
            {
                LocationDescriptions[0] = LocationDescriptions[1];
            }
        }
    }
}
