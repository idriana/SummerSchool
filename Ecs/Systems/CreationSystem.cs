using System;
using Leopotam.EcsLite;
using MyEngine.Ecs.Components;

namespace MyEngine.Ecs.Systems
{
    public class CreationSystem : IEcsInitSystem
    {
        public List<int> _ent;
        public void Init(IEcsSystems systems)
        {
            _ent = systems.GetShared<List<int>>();
            EcsWorld world = systems.GetWorld();
            EcsPool<Transform> tcpool = world.GetPool<Transform>();
            int e1 = world.NewEntity();
            tcpool.Add(e1);
            _ent.Add(e1);
            ref Transform tc = ref tcpool.Get(e1);
        }
    }
}
