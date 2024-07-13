using Commands;
using Commands.GameCommands;
using Commands.UserActionsCommands;
using SummerSchoolGUI.Domain.ValueObjects;
using SummerSchoolGUI.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerSchoolGUI.Infrastructure
{
    public class CommandProvider : IService
    {
        private Dictionary<Type, ICommandFactory> commandFactories = new Dictionary<Type, ICommandFactory>();

        public CommandProvider()
        {
            commandFactories.Add(typeof(EntityListCommand), new EntityListCommandFactory());
            commandFactories.Add(typeof(CloseWindowCommand), new CloseWindowCommandFactory());
        }

        public ICommand? CreateCommand<TCommand, TData>(TData data) where TCommand : IValueCommand<TData>
        {
            IValueCommandFactory<TCommand, TData> factory = (IValueCommandFactory<TCommand, TData>)commandFactories[typeof(TCommand)];
            if (factory == null)
            {
                throw new ArgumentException($"Couldn't find appropriate command factory for command of type {typeof(TCommand)}");
            }
            return factory.CreateCommand(data);
        }

        public ICommand? CreateCommand<TCommand>() where TCommand : IEmptyCommand
        {
            IEmptyCommandFactory<TCommand> factory = (IEmptyCommandFactory<TCommand>)commandFactories[typeof(TCommand)];
            if (factory == null)
            {
                throw new ArgumentException($"Couldn't find appropriate command factory for command of type {typeof(TCommand)}");
            }
            return factory.CreateCommand();
        }
    }
}
