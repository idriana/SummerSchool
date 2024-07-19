using Commands;
using MyEngine.Ecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEngine.Gui.Handlers
{
    public interface IHandler
    {
        public void Execute(ICommand command);
    }
}
