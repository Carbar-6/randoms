using System;
namespace TextGame.Locations
{
    public class Castle : Location
    {
        public Castle(string name, string description, string descriptionShort, string descriptionNoItems)
        {
            Name = name;
            LocationDescriptions = new string[] { description, descriptionShort, descriptionNoItems};
            

        }

        public override void doCommand(string[] inCommand, Player player)
        {
            throw new NotImplementedException();
        }
    }
}
