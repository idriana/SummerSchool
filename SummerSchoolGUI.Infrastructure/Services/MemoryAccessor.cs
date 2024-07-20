using SummerSchoolGUI.Domain.ValueObjects;

namespace SummerSchoolGUI.Infrastructure.Services
{
    public class MemoryAccessor : IService
    {
        private int current_entity = 0;
        private List<Entity> entities = new();

        public MemoryAccessor() 
        {
        }

        public Entity Entity { get 
            {
                Entity res = null;
                if (entities.Count != 0)
                {
                    res = entities[current_entity].Copy();
                }
                return res;
            }}

        public List<Entity> Entities { get
            {
                List<Entity> copy = new List<Entity>();
                foreach (Entity entity in entities)
                    copy.Add(entity.Copy());
                return copy;
            }
        }

        public event EventHandler PresentationChanged; // GameViewModel
        public event EventHandler<List<Entity>> EntityCollectionUpdated; // currently not used
        public event EventHandler<Entity> SelectedEntityUpdated; // ComponentsViewModel
        public event EventHandler<IComponent> SelectedEntityComponentUpdated; // any component ViewModel

        private void OnEntityCollectionUpdated()
        {
            //EntityCollectionUpdated(this, this.entities);
        }

        private void OnSelectedEntityUpdated()
        {
            SelectedEntityUpdated(this, this.entities[current_entity]);
        }

        private void OnComponentUpdated(IComponent component)
        {
            SelectedEntityComponentUpdated(this, component);
        }

        public void UpdateEntityCollection(List<Entity> newEntities)
        {
            // check if selected object changed
            if (newEntities.Count < current_entity)
                current_entity = 0;
            if (newEntities.Count != 0 && (entities.Count == 0 || entities[current_entity] != newEntities[current_entity]))
                UpdateSelectedEntity(newEntities[current_entity]);

            // update entities list
            this.entities = newEntities;
            OnEntityCollectionUpdated();
        }

        public void UpdateSelectedEntity(Entity entity)
        {
            if (entities.Count == 0)
            {
                entities.Add(entity);
                current_entity = 0;
                OnEntityCollectionUpdated();
                OnSelectedEntityUpdated();
            }
            else if (entities[current_entity].HasSameComponents(entity))
            {
                foreach (IComponent component in entity.components)
                {
                    UpdateSelectedEntityComponent(component);
                }
            }
            else
            {
                entities[current_entity] = entity;
                OnSelectedEntityUpdated();
            }
        }

        public void UpdateSelection(int entity_num)
        {
            current_entity = entity_num;
            OnSelectedEntityUpdated();
        }

        public void UpdateSelectedEntityComponent(IComponent component)
        {
            Entity currEntity = entities[current_entity];
            for (int i = 0; i < currEntity.components.Count; i++)
            {
                if (currEntity.components[i].GetType() == component.GetType())
                {
                    if (!currEntity.components[i].HasSameValues(component))
                    {
                        currEntity.components[i] = component;
                        OnComponentUpdated(component);
                    }
                    return;
                }
            }
            throw new ArgumentException($"Can't update entity component of type {component.GetType()}. Entity does not have this component!");
        }

        public void UpdatePresentations()
        {
            PresentationChanged(this, EventArgs.Empty);
        }
    }
}
