using System;
using System.Collections.Generic;

namespace TextGame.Locations
{
    public class Cave : Location, IRoom
    {
        public Cave(string name, string description, string descriptionShort, string descriptionNoItems)
        {
            Name = name;
            LocationDescriptions = new string[]{description, descriptionShort, descriptionNoItems};
            Paths = new Location[4];
            NumberOfVisits = 0;
            itemsInLocation = new List<Item>();
            NPCsInLocation = new List<NPC>();
            PlayerHasInteractedWithLocation = false;
        }

        public int Size { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void doCommand(string[] command, Player player)
        {
            if (player.HasMovedToNewLocation == false && player.Position.Name.Equals(Name))
            {
                switch (command[0])
                {
                    case "west":
                        player.moveTo(Paths[Directions.WEST]);
                        break;
                    case "south":
                        player.moveTo(Paths[Directions.SOUTH]);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
