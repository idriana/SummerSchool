using System;
using System.Numerics;

namespace MyEngine.Ecs.Components
{
    public struct MoveData : IECSComponent
    {
        public Vector2 Velocity;
    }
}
