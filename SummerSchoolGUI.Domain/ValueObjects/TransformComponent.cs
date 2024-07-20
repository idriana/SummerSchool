//using MyEngine.Ecs.Components;

namespace SummerSchoolGUI.Domain.ValueObjects
{
    public class TransformComponent : IComponent
    {
        public float posX = 100;
        public float posY = 100;
        public float rotX = 0;
        public float rotY = 0;
        public float scaleX = 10;
        public float scaleY = 10;

        public IComponent Copy()
        {
            return new TransformComponent
            {
                posX = this.posX,
                posY = this.posY,
                rotX = this.rotX,
                rotY = this.rotY,
                scaleX = this.scaleX,
                scaleY = this.scaleY
            };
        }
        //public void Update(Transform tc)

        public bool HasSameValues(IComponent other)
        {
            if (other is TransformComponent component)
            {
                return posX == component.posX && posY == component.posY && 
                       rotX == component.rotX && rotY == component.rotY && 
                       scaleX == component.scaleX && scaleY == component.scaleY;
            }
            return false;
        }
    }
}
