using MyEngine.Ecs.Components;
using SummerSchoolGUI.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEngine.Gui.DataConverters
{
    public class Converter
    {

        private Dictionary<Type, IConverter> converters = new Dictionary<Type, IConverter>();

        public Converter() 
        {
            converters[typeof(TransformComponent)] = new TransformConverter();
        }

        public IECSComponent Convert(IComponent guiComponent)
        {
            IConverter converter = converters[guiComponent.GetType()];
            if (converter == null)
            {
                throw new ArgumentException($"Couldn't find appropriate converter for gui component of type {guiComponent.GetType()}");
            }
            return converter.Convert(guiComponent);
        }
    }
}
