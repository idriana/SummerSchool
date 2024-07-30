using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public abstract class EntityPresentationBase 
    {
        Vector2 Position;
        Vector2 Rotation;
        Vector2 Scale;

        public float PosX { get { return Position.X; } set { Position.X = value; } }
        public float PosY { get { return Position.Y; } set { Position.Y = value; } }
        public float RotX { get { return Rotation.X; } set { Rotation.X = value; } }
        public float RotY { get { return Rotation.Y; } set { Rotation.Y = value; } }
        public float ScaleX { get { return Scale.X; } set { Scale.X = value; } }
        public float ScaleY { get { return Scale.Y; } set { Scale.Y = value; } }
    }
}
