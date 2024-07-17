using SummerSchoolGUI.Domain.ValueObjects;
using System;

namespace MyEngine.Ecs.Components
{
    public struct Transform
    {
        public float posX;
        public float posY;
        public float rotX;
        public float rotY;
        public float scaleX;
        public float scaleY;

        public void Update(TransformComponent tc)
        {
            posX = tc.posX;
            posY = tc.posY;
            rotX = tc.rotX;
            rotY = tc.rotY;
            scaleX = tc.scaleX;
            scaleY = tc.scaleY;
        }
    }
}
