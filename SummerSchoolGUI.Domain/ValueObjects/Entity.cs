using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerSchoolGUI.Domain.ValueObjects
{
    public record Entity
    {
        int id;
        public List<IComponent> components = new List<IComponent>();

        public int ID { get { return id; } }

        public Entity(int id)
        {
            this.id = id;
        }

        public Entity Copy() 
        { 
            Entity copy = new Entity(id);
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

        public bool HasSameComponents(Entity other)
        {
            if (components.Count != other.components.Count)
                return false;
            for (int i = 0; i < components.Count; i++) 
            {
                if (components[i].GetType() != other.components[i].GetType())
                    return false;
            }
            return true;
        }
    }
}
