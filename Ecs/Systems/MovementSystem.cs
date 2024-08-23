using System;
using Leopotam.EcsLite;
using MyEngine.Ecs.Components;

namespace MyEngine.Ecs.Systems
{
    public class MovementSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter _moveFilter;
        private EcsFilter _worldBoxFilter;
        private EcsPool<MoveData> _movementPool;
        private EcsPool<Transform> _transformPool;
        private EcsPool<WorldBox> _worldBoxPool; 

        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _moveFilter = world.Filter<MoveData>().End();
            _worldBoxFilter = world.Filter<WorldBox>().End();
            _movementPool = world.GetPool<MoveData>();
            _transformPool = world.GetPool<Transform>();
            _worldBoxPool = world.GetPool<WorldBox>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _moveFilter)
            {
                ref MoveData md = ref _movementPool.Get(entity);
                ref Transform transform = ref _transformPool.Get(entity);
                transform.Position += md.Velocity;
                CheckWorldBox(ref transform, ref md);
            }
        }

        public void CheckWorldBox(ref Transform transform, ref MoveData md)
        {
            foreach (var entity in _worldBoxFilter)
            {
                ref WorldBox wb = ref _worldBoxPool.Get(entity);
                if (transform.Position.X > wb.right && md.Velocity.X >= 0)
                {
                    transform.Position.X = 2 * wb.right - transform.Position.X;
                    md.Velocity.X = -md.Velocity.X;
                }
                if (transform.Position.X < wb.left && md.Velocity.X <= 0)
                {
                    transform.Position.X = 2 * wb.left - transform.Position.X;
                    md.Velocity.X = -md.Velocity.X;
                }
                if (transform.Position.Y < wb.top && md.Velocity.Y <= 0)
                {
                    transform.Position.Y = 2 * wb.top - transform.Position.Y;
                    md.Velocity.Y = -md.Velocity.Y;
                }
                if (transform.Position.Y > wb.bottom && md.Velocity.Y >= 0)
                {
                    transform.Position.Y = 2 * wb.bottom - transform.Position.Y;
                    md.Velocity.Y = -md.Velocity.Y;
                }
            }
        }
    }
}
