using System.Collections.Generic;

namespace ClothesWashingApp.Commands
{
    class NullCommand : ICommand
    {
        public void Execute(IEnumerable<string> arguments)
        {
        }
    }
}
