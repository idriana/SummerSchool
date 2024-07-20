using MyEngine.Ecs.Components;
using SummerSchoolGUI.Domain.ValueObjects;

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

        public IComponent Convert(IECSComponent coreComponent)
        {
            if (coreComponent is Transform coreTransform)
            {
                return new TransformComponent
                {
                    posX = coreTransform.posX,
                    posY = coreTransform.posY,
                    rotX = coreTransform.rotX,
                    rotY = coreTransform.rotY,
                    scaleX = coreTransform.scaleX,
                    scaleY = coreTransform.scaleY
                };
            }
            else
            {
                throw new ArgumentException($"Expected to get gui component of type TransformComponent, got {coreComponent.GetType()}");
            }
        }
    }
}
