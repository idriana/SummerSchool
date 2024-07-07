using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commands;

namespace SummerSchoolGUI.Infrastructure.Services
{
    public class GUIObserver : IService
    {
        private CommandProvider _commandProvider;
        private ConcurrentQueue<ICommand> commandQueue = new();

        public GUIObserver(CommandProvider commandProvider)
        {
            _commandProvider = commandProvider;
        }

        public void AddData<T>(T data)
        {
            ICommand command = _commandProvider.CreateCommand(data);
            commandQueue.Enqueue(command);
        }

        public ICommand? GetNextCommand() 
        {
            if (commandQueue.Count == 0)
            {
                return null;
            }
            if (!commandQueue.TryDequeue(out var item))
                throw new InvalidOperationException("Couldn't dequeue item when queue is not empty");
            return item;
        }
    }
}
