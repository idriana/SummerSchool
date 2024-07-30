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
            transform.Position = new System.Numerics.Vector2(100, 100);
            transform.Scale = new System.Numerics.Vector2(10, 10);
            
            ref MoveData moveData = ref world.GetPool<MoveData>().Get(e1);
            moveData.Velocity.Y = 1;
        }
    }
}
