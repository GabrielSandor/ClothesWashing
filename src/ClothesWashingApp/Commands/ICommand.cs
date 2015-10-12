using System.Collections.Generic;

namespace ClothesWashingApp.Commands
{
    interface ICommand
    {
        void Execute(IEnumerable<string> arguments);
    }
}