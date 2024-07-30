using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SummerSchoolGUI.Domain.ValueObjects
{
    public record MoveComponent : IComponent
    {
        public Vector2 Velocity;

        public IComponent Copy()
        {
            return new MoveComponent
            {
                Velocity = Velocity
            };
        }

        public bool HasSameValues(IComponent other)
        {
            if (other is MoveComponent component)
            {
                return Velocity == component.Velocity;
            }
            return false;
        }
    }
}
