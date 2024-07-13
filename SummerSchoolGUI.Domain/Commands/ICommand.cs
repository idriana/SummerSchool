using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands
{
    public interface ICommand
    {

    }

    public interface IEmptyCommand : ICommand
    {

    }

    public interface IValueCommand<T>: ICommand
    {
        public T Value { get; set; }
    }
}
