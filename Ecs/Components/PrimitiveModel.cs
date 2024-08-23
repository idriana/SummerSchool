using MyEngine.Ecs.Components.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEngine.Ecs.Components
{
    public struct PrimitiveModel : IECSComponent
    {
        public bool Fill;
        public IPrimitiveShape Shape;
    }
}
