using Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerSchoolGUI.Infrastructure.Services
{
    public class CoreObserver : IService
    {
        private Action<Action> UIThreadCallback;
        private CommandProvider CommandProvider;
        private CommandHandler CommandHandler;

        public CoreObserver(Action<Action> uIThreadCallback, CommandProvider commandProvider, CommandHandler commandHandler)
        {
            UIThreadCallback = uIThreadCallback;
            CommandHandler = commandHandler;
            CommandProvider = commandProvider;
        }

        public void AddCommand<TCommand, TData>(TData data) where TCommand : IValueCommand<TData>
        {
            ICommand command = CommandProvider.CreateCommand<TCommand, TData>(data);
            ExecuteCommand(command);
        }

        public void AddCommand<TCommand>() where TCommand : IEmptyCommand
        {
            ICommand command = CommandProvider.CreateCommand<TCommand>();
            ExecuteCommand(command);
        }

        private void ExecuteCommand(ICommand command)
        {
            UIThreadCallback.Invoke(() => CommandHandler.Execute(command));
        }
    }
}
