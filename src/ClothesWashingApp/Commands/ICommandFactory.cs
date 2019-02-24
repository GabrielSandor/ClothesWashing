namespace ClothesWashingApp.Commands
{
    internal interface ICommandFactory
    {
        ICommand CreateCommand(string commandTypeSwitch);
    }
}