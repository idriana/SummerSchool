using MyEngine.Ecs.Components;
using SummerSchoolGUI.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEngine.Gui.DataConverters
{
    public class MoveConverter : IConverter
    {
        public IECSComponent Convert(IComponent guiComponent)
        {
            if (guiComponent is MoveComponent guiTransform)
            {
                return new MoveData
                {
                    Velocity = guiTransform.Velocity
                };
            }
            else
            {
                throw new ArgumentException($"Expected to get gui component of type TransformComponent, got {guiComponent.GetType()}");
            }
        }

        public IComponent Convert(IECSComponent coreComponent)
        {
            if (coreComponent is MoveData coreTransform)
            {
                return new MoveComponent
                {
                    Velocity = coreTransform.Velocity
                };
            }
            else
            {
                throw new ArgumentException($"Expected to get gui component of type TransformComponent, got {coreComponent.GetType()}");
            }
        }
    }
}
