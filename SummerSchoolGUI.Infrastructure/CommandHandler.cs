using Commands;
using Commands.GameCommands;
using SummerSchoolGUI.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerSchoolGUI.Infrastructure
{
    public class CommandHandler
    {
        private IServiceProvider serviceProvider;

        public CommandHandler(IServiceProvider ServiceProvider) 
        {
            this.serviceProvider = ServiceProvider;
        }

        public void Execute(ICommand command)
        {
            if (command is EntityListCommand entityListCommand)
            {
                serviceProvider.GetService<MemoryAccessor>().UpdateEntityCollection(entityListCommand.Value);
            }
            serviceProvider.GetService<MemoryAccessor>().UpdatePresentations();
        }
    }
}
