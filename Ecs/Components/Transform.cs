using System;
using System.Numerics;

namespace MyEngine.Ecs.Components
{
    public struct Transform : IECSComponent
    {
        public Vector2 Position;
        public Vector2 Rotation;
        public Vector2 Scale;
    }
}
