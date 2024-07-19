using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commands;
using Commands.GameCommands;
using Commands.UserActionsCommands;
using MyEngine.Ecs;
using MyEngine.Gui.DataConverters;
using MyEngine.Gui.Handlers;
using SummerSchoolGUI.Infrastructure;
using SummerSchoolGUI.Infrastructure.Services;

namespace MyEngine.Gui
{
    public class MyGui
    {
        private Thread? _thread;
        private MyEcs ecs;
        private Dictionary<Type, IHandler> handlers = new Dictionary<Type, IHandler>();
        private Converter converter;

        public MyGui(MyEcs ecs)
        {
            _thread = new Thread(() => SummerSchoolGUI.Desktop.Program.Main(new string[] { }));
            _thread.Start();
            this.ecs = ecs;
            converter = new Converter();
            Init();

            while (!GUIAPI.Initialized)
            {
                // wait for services to load
            }
        }

        private void Init()
        {
            handlers[typeof(EntityListCommand)] = new EntityListCommandHandler(ecs, converter);
            handlers[typeof(CloseWindowCommand)] = new CloseWindowCommandHandler();
        }

        public void Update()
        {
            getCommands();
        }

        private void getCommands()
        {
            var observer = GUIAPI.GetService<GUIObserver>();
            ICommand command = observer.GetNextCommand();
            while (command != null)
            {
                IHandler handler = handlers[command.GetType()];
                if (handler == null)
                {
                    throw new ArgumentNullException($"Couldn't find appropriate handler for command of type {command.GetType()}");
                }
                handler.Execute(command);
                command = observer.GetNextCommand();
            }
        }

        private void sendCommands()
        {
            var observer = GUIAPI.GetService<CoreObserver>();
            
        }
    }
}
