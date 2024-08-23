using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MyEngine.Ecs.Components.Primitives
{
    public struct Circle : IPrimitiveShape
    {
        public Vector2 Center;
        public float Radius;
    }
}
