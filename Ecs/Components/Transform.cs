using System;

namespace MyEngine.Ecs.Components
{
    public struct Transform : IECSComponent
    {
        public float posX;
        public float posY;
        public float rotX;
        public float rotY;
        public float scaleX;
        public float scaleY;
    }
}
