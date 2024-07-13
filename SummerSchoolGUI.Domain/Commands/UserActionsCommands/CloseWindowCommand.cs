using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.UserActionsCommands
{
    public class CloseWindowCommand : IEmptyCommand
    {
    }

    public class CloseWindowCommandFactory : IEmptyCommandFactory<CloseWindowCommand>
    {
        public ICommand CreateCommand()
        {
            return new CloseWindowCommand();
        }
    }
}
