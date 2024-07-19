using MyEngine.Ecs;
using MyEngine.Gui.DataConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEngine.Gui.Handlers
{
    public interface IECSHandler : IHandler
    {
        public MyEcs Ecs { get; }
        public Converter Converter { get; }
    }
}
