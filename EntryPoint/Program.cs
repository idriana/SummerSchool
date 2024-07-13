using Commands;
using Commands.GameCommands;
using Commands.UserActionsCommands;
using SummerSchoolGUI.Domain.ValueObjects;
using SummerSchoolGUI.Infrastructure;
using SummerSchoolGUI.Infrastructure.Services;
using System.Diagnostics;

namespace EntryPoint // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static async Task Main(string[] args)
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
            observer.AddCommand<EntityListCommand, List<Entity>>(entities);

            GUIObserver GUIObserver = GUIAPI.GetService<GUIObserver>();
            PeriodicTimer timer = new PeriodicTimer(TimeSpan.FromMilliseconds(100));
            while (await timer.WaitForNextTickAsync())
            {
                ICommand command = GUIObserver.GetNextCommand();
                if (command != null && command is EntityListCommand entityListCommand)
                {
                    Thread.Sleep(100);
                    foreach (Entity e in entityListCommand.Value)
                    {
                        e.Transform.posY += 1;
                    }
                    observer.AddCommand<EntityListCommand, List<Entity>>(entities);
                }
                else if (command != null && command is CloseWindowCommand)
                {
                    Environment.Exit(0);
                }
            }
        }

        //class MainLoop
        //{
        //    private Stopwatch stopwatch = new Stopwatch();
        //    private GameTime gameTime;
        //    private PeriodicTimer timer = new PeriodicTimer(TimeSpan.FromMilliseconds(100));

        //    public async void Run()
        //    {
        //        stopwatch.Start();
        //        while (await timer.WaitForNextTickAsync())
        //        {
        //            Tick();
        //        }
        //    }

        //    private void Tick()
        //    {
        //        gameTime.elapsedTotal += stopwatch.Elapsed;
        //        // check for commands
        //        // update ecs
        //    }
        //}
    }
}
