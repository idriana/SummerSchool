using MyEngine.Ecs.Components;
using SummerSchoolGUI.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEngine.Gui.DataConverters
{
    public class TransformConverter : IConverter
    {
        public IECSComponent Convert(IComponent guiComponent)
        {
            if (guiComponent is TransformComponent guiTransform)
            {
                return new Transform
                {
                    posX = guiTransform.posX,
                    posY = guiTransform.posY,
                    rotX = guiTransform.rotX,
                    rotY = guiTransform.rotY,
                    scaleX = guiTransform.scaleX,
                    scaleY = guiTransform.scaleY
                };
            }
            else
            {
                throw new ArgumentException($"Expected to get gui component of type TransformComponent, got {guiComponent.GetType()}");
            }
        }
    }
}
