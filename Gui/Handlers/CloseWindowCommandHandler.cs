using Commands;
using Commands.GameCommands;
using Commands.UserActionsCommands;
using MyEngine.Ecs;
using SummerSchoolGUI.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEngine.Gui.Handlers
{
    public class CloseWindowCommandHandler : IHandler
    {
        public void Execute(ICommand command)
        {
            if (command is CloseWindowCommand entityListCommand)
            {
                Environment.Exit(0);
                return;
            }
            throw new ArgumentException($"Expected command of type EntityListCommand, got {command.GetType()}");
        }
    }
}
