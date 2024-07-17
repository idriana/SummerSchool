using System;
using Leopotam.EcsLite;
using MyEngine.Ecs.Components;
using SummerSchoolGUI.Domain.ValueObjects;

namespace MyEngine.Ecs.Systems
{
    public class CreationSystem : IEcsInitSystem
    {
        public List<Entity> _ent;
        public void Init(IEcsSystems systems)
        {
            _ent = systems.GetShared<List<Entity>>();
            _ent.Add(
                new Entity()
                {
                    components = new List<IComponent>()
                    {
                        new SummerSchoolGUI.Domain.ValueObjects.TransformComponent()
                        {
                            posX = 100,
                            posY = 100,
                            rotX = 0,
                            rotY = 0,
                            scaleX = 10,
                            scaleY = 10
        }
                    }
                });

            EcsWorld world = systems.GetWorld();
            EcsPool<Transform> tcpool = world.GetPool<Transform>();
            int e1 = world.NewEntity();
            tcpool.Add(e1);
            ref Transform tc = ref tcpool.Get(e1);
            tc.Update(_ent[0].Transform);

        }
    }
}
