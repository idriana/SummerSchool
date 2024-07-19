using System;
using Leopotam.EcsLite;
using MyEngine.Ecs.Components;

namespace MyEngine.Ecs.Systems
{
    public class OutputSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter _filter;
        private EcsPool<MoveData> _movementPool;
        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<MoveData>().End();
            _movementPool = world.GetPool<MoveData>();
        }
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                ref MoveData md = ref _movementPool.Get(entity);
                Console.WriteLine($"Entity {entity} dx: {md.dx}, dy: {md.dy}");
            }
        }
    }
}
