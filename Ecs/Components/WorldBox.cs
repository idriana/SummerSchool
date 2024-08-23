using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        public readonly Vector2 TopLeft => new Vector2(left, top);
        public readonly Vector2 BottomRight => new Vector2(right, bottom);
    }
}
