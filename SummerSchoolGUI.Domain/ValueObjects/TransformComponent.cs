//using MyEngine.Ecs.Components;

using System.Numerics;

namespace SummerSchoolGUI.Domain.ValueObjects
{
    public class TransformComponent : IComponent
    {
        public Vector2 Position = new Vector2(100, 100);
        public Vector2 Rotation = new(0, 0);
        public Vector2 Scale = new(10, 10);
        
        public IComponent Copy()
        {
            return new TransformComponent
            {
                Position = Position, Rotation = Rotation, Scale = Scale
            };
        }
        //public void Update(Transform tc)

        public bool HasSameValues(IComponent other)
        {
            if (other is TransformComponent component)
            {
                return Position == component.Position && Rotation == component.Rotation && Scale == component.Scale;
            }
            return false;
        }
    }
}
