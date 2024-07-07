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

    public interface ICommandFactory<T> : ICommandFactory
    {
        public ICommand CreateCommand(T data);
    }
}
