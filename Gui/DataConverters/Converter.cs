using MyEngine.Ecs.Components;
using SummerSchoolGUI.Domain.ValueObjects;

namespace MyEngine.Gui.DataConverters
{
    public class Converter
    {

        private Dictionary<Type, IConverter> guiCoreConverters = new Dictionary<Type, IConverter>();
        private Dictionary<Type, IConverter> coreGuiConverters = new Dictionary<Type, IConverter>();

        public Converter() 
        {
            guiCoreConverters[typeof(TransformComponent)] = new TransformConverter();
            coreGuiConverters[typeof(Transform)] = guiCoreConverters[typeof(TransformComponent)];

            guiCoreConverters[typeof(MoveComponent)] = new MoveConverter();
            coreGuiConverters[typeof(MoveData)] = guiCoreConverters[typeof(MoveComponent)];
        }

        public IECSComponent ConvertToCore(IComponent guiComponent)
        {
            IConverter converter = guiCoreConverters[guiComponent.GetType()];
            if (converter == null)
            {
                throw new ArgumentException($"Couldn't find appropriate converter for gui component of type {guiComponent.GetType()}");
            }
            return converter.Convert(guiComponent);
        }

        public IComponent? ConvertToGui(IECSComponent coreComponent)
        {
            IConverter? converter = coreGuiConverters!.GetValueOrDefault(coreComponent.GetType(), null);
            if (converter == null)
            {
                return null;
                //throw new ArgumentException($"Couldn't find appropriate converter for gui component of type {coreComponent.GetType()}");
            }
            return converter.Convert(coreComponent);
        }
    }
}
