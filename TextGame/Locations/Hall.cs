using System;
using System.Collections.Generic;

namespace TextGame.Locations
{
    public class Hall : Location, IRoom
    {
        public Hall(string name, string description, string descriptionShort, string descriptionNoItems)
        {
            Name = name;
            Paths = new Location[4];
            NumberOfVisits = 0;
            itemsInLocation = new List<Item>();
            NPCsInLocation = new List<NPC>();
            PlayerHasInteractedWithLocation = false;
            LocationDescriptions = new string[] { description, descriptionShort, descriptionNoItems };
        }

        public int Size { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void doCommand(String[] command, Player player)
        {
            if (player.HasMovedToNewLocation == false && player.Position.Name.Equals(Name))
            {
                switch (command[0])
                {
                    case "east":
                        player.moveTo(Paths[Directions.EAST]);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
