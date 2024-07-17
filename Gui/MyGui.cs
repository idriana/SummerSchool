using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummerSchoolGUI.Infrastructure;

namespace MyEngine.Gui
{
    public class MyGui
    {
        private Thread? _thread;
        public MyGui()
        {
            _thread = new Thread(() => SummerSchoolGUI.Desktop.Program.Main(new string[] { }));
            _thread.Start();

            while (!GUIAPI.Initialized)
            {
                // wait for services to load
            }
        }
        public void Run()
        {
            Console.WriteLine("MyGui.Run");
        }
    }
}
