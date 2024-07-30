using SummerSchoolGUI.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class EntityPresentation : EntityPresentationBase
    {
        public EntityPresentation(float PosX, float PosY, float RotX, float RotY, float ScaleX, float ScaleY)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            this.RotX = RotX;
            this.RotY = RotY;
            this.ScaleX = ScaleX;
            this.ScaleY = ScaleY;
        }

        public EntityPresentation(Vector2 Position, Vector2 Rotation, Vector2 Scale)
            : this(Position.X, Position.Y, Rotation.X, Rotation.Y, Scale.X, Scale.Y)
        { }

        public EntityPresentation(TransformComponent transform)
            : this(transform.Position, transform.Rotation, transform.Scale)
        { }
    }
}
