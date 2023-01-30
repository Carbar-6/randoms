namespace TextGame
{
    public interface ICommandable
    {
        void doCommand(string[] command, Player player);
    }
}
