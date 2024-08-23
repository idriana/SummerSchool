using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MyEngine.Ecs.Components.Primitives
{
    public struct Rectangle : IPrimitiveShape
    {
        public Vector2 TopLeft;
        public Vector2 BottomRight;
    }
}
