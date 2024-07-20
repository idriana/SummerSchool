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
            int e1 = world.NewEntity();

            world.GetPool<Transform>().Add(e1);
            world.GetPool<MoveData>().Add(e1);
            
            _ent.Add(e1);

            ref Transform transform = ref world.GetPool<Transform>().Get(e1);
            transform.posX = 100;
            transform.posY = 100;
            transform.scaleX = 10;
            transform.scaleY = 10;
            
            ref MoveData moveData = ref world.GetPool<MoveData>().Get(e1);
            moveData.dy = 1;
        }
    }
}
