using Commands;
using Commands.GameCommands;
using Commands.UserActionsCommands;
using SummerSchoolGUI.Domain.ValueObjects;
using SummerSchoolGUI.Infrastructure;
using SummerSchoolGUI.Infrastructure.Services;
using System.Diagnostics;
using MyEngine.Gui;
using MyEngine.Ecs;

namespace MyEngine
{
    public class EntryPoint
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            MyEcs ecs = new MyEcs();
            MyGui gui = new MyGui(ecs);

            PeriodicTimer timer = new PeriodicTimer(TimeSpan.FromMilliseconds(20));

            while (await timer.WaitForNextTickAsync())
            {
                ecs.Update();
                gui.Update();
            }
        }
    }
}
