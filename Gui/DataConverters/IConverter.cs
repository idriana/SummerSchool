using MyEngine.Ecs.Components;
using SummerSchoolGUI.Domain.ValueObjects;

namespace MyEngine.Gui.DataConverters
{
    public interface IConverter
    {
        public IECSComponent Convert(IComponent component);
    }
}
