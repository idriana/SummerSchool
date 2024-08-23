using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEngine.Ecs.Components
{
    public struct WorldBox : IECSComponent
    {
        public float top;
        public float bottom;
        public float left;
        public float right;

        public readonly float Width => right - left;
        public readonly float Height => bottom - top;
    }
}
