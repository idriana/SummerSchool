using System;
using Leopotam.EcsLite;
using MyEngine.Ecs.Components;

namespace MyEngine.Ecs.Systems
{
    public class CreationSystem : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsPool<MoveData> mdpool = world.GetPool<MoveData>();
            int e1 = world.NewEntity();
            int e2 = world.NewEntity();
            mdpool.Add(e1);
            mdpool.Add(e2);
            ref MoveData md = ref mdpool.Get(e1);
            md.x = 10;
            md.y = 10;
            md.dx = 1;
            md.dy = 2;
            md = ref mdpool.Get(e2);
            md.x = 10;
            md.y = 10;
            md.dx = -1;
            md.dy = -2;
        }
    }
}
