using System;
using Leopotam.EcsLite;
using MyEngine.Ecs.Components;

namespace MyEngine.Ecs.Systems
{
    public class MovementSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter _moveFilter;
        private EcsPool<MoveData> _movementPool;
        private EcsPool<Transform> _transformPool;

        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _moveFilter = world.Filter<MoveData>().End();
            _movementPool = world.GetPool<MoveData>();
            _transformPool = world.GetPool<Transform>();
        }
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _moveFilter)
            {
                ref MoveData md = ref _movementPool.Get(entity);
                ref Transform transform = ref _transformPool.Get(entity);
                transform.posX += md.dx; 
                transform.posY += md.dy;
            }
        }
    }
}
