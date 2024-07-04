using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.GameCommands
{
    public interface IGameCommand : ICommand
    {
    }

    public interface IGameCommand<T> : IGameCommand
    {
        public T Value { get; set; }
    }
}
