using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.UserActionsCommands
{
    public class CloseWindowCommand : ICommand
    {
    }

    public class CloseWindowCommandFactory
    {
        public ICommand CreateCommand(int data)
        {
            return new CloseWindowCommand();
        }
    }
}
