using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerSchoolGUI.Domain.ValueObjects
{
    public record Entity
    {
        public List<IComponent> components = new List<IComponent>();

        public Entity Copy() 
        { 
            Entity copy = new Entity();
            foreach (var component in components) 
            { 
                copy.components.Add(component.Copy());
            }
            return copy;
        }

        public TransformComponent Transform { get
            {
                foreach(var component in components)
                {
                    if (component is TransformComponent transformComponent)
                        return transformComponent;
                }
                return null;
            } 
        }
    }
}
