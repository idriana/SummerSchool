using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerSchoolGUI.Domain.ValueObjects
{
    public record MoveComponent : IComponent
    {
        public float dx;
        public float dy;

        public IComponent Copy()
        {
            return new MoveComponent
            {
                dx = this.dx,
                dy = this.dy
            };
        }

        public bool HasSameValues(IComponent other)
        {
            if (other is MoveComponent component)
            {
                return dx == component.dx && dy == component.dy;
            }
            return false;
        }


    }
}
