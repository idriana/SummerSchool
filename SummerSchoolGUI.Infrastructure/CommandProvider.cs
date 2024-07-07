using Commands;
using Commands.GameCommands;
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
            commandFactories.Add(typeof(List<Entity>), new EntityListCommandFactory());
        }

        public ICommand? CreateCommand<T>(T data)
        {
            ICommandFactory<T> factory = (ICommandFactory<T>)commandFactories[typeof(T)];
            if (factory == null)
            {
                throw new ArgumentException($"Couldn't find appropriate command factory for data of type {typeof(T)}");
            }
            return factory.CreateCommand(data);
        }
    }
}
