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

            int e1 = CreateEntity(systems);
            world.GetPool<MoveData>().Add(e1);
            ref Transform transform = ref world.GetPool<Transform>().Get(e1);
            transform.Position = new System.Numerics.Vector2(100, 100);
            transform.Scale = new System.Numerics.Vector2(10, 10);
            ref MoveData moveData = ref world.GetPool<MoveData>().Get(e1);
            moveData.Velocity.Y = 1;

            int e = CreateEntity(systems);
            world.GetPool<WorldBox>().Add(e);
            ref WorldBox wb = ref world.GetPool<WorldBox>().Get(e);
            wb.left = 0;
            wb.right = 400;
            wb.top = 0;
            wb.bottom = 400;
        }

        private int CreateEntity(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            int e = world.NewEntity();
            world.GetPool<Transform>().Add(e);
            return e;
        }
    }
}
