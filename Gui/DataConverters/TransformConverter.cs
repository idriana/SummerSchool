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
                    Position = guiTransform.Position,
                    Rotation = guiTransform.Rotation,
                    Scale = guiTransform.Scale,
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
                    Position = coreTransform.Position,
                    Rotation = coreTransform.Rotation,
                    Scale = coreTransform.Scale,
                };
            }
            else
            {
                throw new ArgumentException($"Expected to get gui component of type TransformComponent, got {coreComponent.GetType()}");
            }
        }
    }
}
