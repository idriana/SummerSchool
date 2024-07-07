using Commands;
using Commands.GameCommands;
using SummerSchoolGUI.Domain.ValueObjects;
using SummerSchoolGUI.Infrastructure;
using SummerSchoolGUI.Infrastructure.Services;

namespace EntryPoint // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Thread thread = new Thread(() => SummerSchoolGUI.Desktop.Program.Main(new string[] { }));
            thread.Start();

            while (!GUIAPI.Initialized)
            {
                // wait for services to load
            }

            CoreObserver observer = GUIAPI.GetService<CoreObserver>();
            List<Entity> entities = new List<Entity>()
            {
                new Entity()
                {
                    components = new List<IComponent>()
                    {
                        new TransformComponent()
                    }
                },
                new Entity()
                {
                    components = new List<IComponent>()
                    {
                        new TransformComponent()
                        {
                            posX = 200
                        }
                    }
                },
            };
            observer.AddData(entities);

            GUIObserver GUIObserver = GUIAPI.GetService<GUIObserver>();
            while (true)
            {
                ICommand command = GUIObserver.GetNextCommand();
                if (command != null && command is EntityListCommand entityListCommand)
                {
                    Thread.Sleep(100);
                    foreach (Entity e in entityListCommand.Value)
                    {
                        e.Transform.posY += 1;
                    }
                    observer.AddData(entities);
                }
            }
        }
    }
}
