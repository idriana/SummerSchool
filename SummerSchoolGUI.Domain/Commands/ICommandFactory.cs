using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands
{
    public interface ICommandFactory
    {
    }

    public interface IValueCommandFactory<TCommand, TData> : ICommandFactory where TCommand: IValueCommand<TData> 
    {
        public ICommand CreateCommand(TData data);
    }

    public interface IEmptyCommandFactory<TCommand> : ICommandFactory where TCommand: IEmptyCommand
    {
        public ICommand CreateCommand();
    }
}
