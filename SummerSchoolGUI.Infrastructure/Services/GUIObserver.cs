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

        public void AddCommand<TCommand, TData>(TData data) where TCommand : IValueCommand<TData>
        {
            ICommand command = _commandProvider.CreateCommand<TCommand, TData>(data);
            EnqueueCommand(command);
        }

        public void AddCommand<TCommand>() where TCommand : IEmptyCommand
        {
            ICommand command = _commandProvider.CreateCommand<TCommand>();
            EnqueueCommand(command);
        }

        private void EnqueueCommand(ICommand command)
        {
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
