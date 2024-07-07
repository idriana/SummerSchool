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

        public void AddData<T>(T data)
        {
            ICommand command = CommandProvider.CreateCommand(data);
            UIThreadCallback.Invoke(() => CommandHandler.Execute(command));
        }
    }
}
