using SummerSchoolGUI.Domain.ValueObjects;

namespace SummerSchoolGUI.Infrastructure.Services
{
    public class MemoryAccessor : IService
    {
        private readonly object _memory_lock = new();
        private int current_entity = 0;
        private List<Entity> entities = new();

        public MemoryAccessor() 
        {
            Entity entity = new Entity();
            IComponent component = new TransformComponent() { posX = 100, posY = 100};
            entity.components.Add(component);
            entities.Add(entity);
        }

        public Entity Entity { get 
            {
                Entity res = null;
                lock (_memory_lock)
                {
                    if (entities.Count != 0)
                    {
                        res = entities[current_entity].Copy();
                    }
                }
                return res;
            }}

        public List<Entity> Entities { get
            {
                List<Entity> copy = new List<Entity>();
                lock (_memory_lock)
                {
                    foreach (Entity entity in entities)
                        copy.Add(entity.Copy());
                }
                return copy;
            }
        }

        public event EventHandler<List<Entity>> EntityCollectionUpdated;
        public event EventHandler<Entity> SelectedEntityUpdated;

        public void UpdateEntityCollection(List<Entity> newEntities)
        {
            lock (_memory_lock)
            {
                this.entities = newEntities;
            }
            OnEntityCollectionUpdated();
        }

        private void OnEntityCollectionUpdated()
        {
            EntityCollectionUpdated(this, this.entities);
        }

        public void UpdateSelectedEntity(Entity entity)
        {
            lock (_memory_lock)
            {
                entities[current_entity] = entity;
            }
            OnSelectedEntityUpdated();
        }

        private void OnSelectedEntityUpdated()
        {
            SelectedEntityUpdated(this, this.entities[current_entity]);
            OnEntityCollectionUpdated();
        }

        public void UpdateSelection(int entity_num)
        {
            lock (_memory_lock)
            {
                current_entity = entity_num;
            }
            OnSelectedEntityUpdated();
        }

        public void UpdateSelectedEntityComponent(IComponent component)
        {
            lock (_memory_lock)
            {
                Entity currEntity = entities[current_entity];
                for (int i = 0; i < currEntity.components.Count; i++)
                {
                    if (currEntity.components[i].GetType() == component.GetType())
                    {
                        currEntity.components[i] = component;
                        break;
                    }
                }
            }
            OnSelectedEntityUpdated();
        }
    }
}
