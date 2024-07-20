using System;
using System.Diagnostics.Tracing;
using Leopotam.EcsLite;
using MyEngine.Ecs.Components;
using MyEngine.Ecs.Systems;

namespace MyEngine.Ecs
{
    public class MyEcs
    {
        private EcsWorld _world;
        private IEcsSystems _systems;
        private List<int> _ent;

        public int[] Entities
        {
            get
            {
                int[] entities = new int[_world.GetEntitiesCount()];
                _world.GetAllEntities(ref entities);
                return entities;
            }
        }

        public IEcsPool[] Pools
        {
            get
            {
                IEcsPool[] pools = new IEcsPool[_world.GetPoolsCount()];
                _world.GetAllPools(ref pools);
                return pools;
            }
        }

        public MyEcs()
        {
            _ent = new List<int>();

            _world = new EcsWorld();
            _systems = new EcsSystems(_world, _ent);
            _systems
                .Add(new CreationSystem())
                .Add(new MovementSystem())
                .Add(new OutputSystem())
                .Init();
        }
        public void Update()
        {
            _systems?.Run();
        }
        public void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
            }
            if (_world != null)
            {
                _world.Destroy();
                _world = null;
            }
        }

        public void UpdateEntity(int Entity, IECSComponent component)
        {
            IEcsPool pool = _world.GetExitstingRawPool(component.GetType());
            if (pool.Has(Entity))
            {
                IECSComponent ecsComponent = pool.GetRaw(Entity) as IECSComponent;
                pool.SetRaw(Entity, component);
            }
            else
            {
                pool.AddRaw(Entity, component);
            }
        }

        public void CreateEntity()
        {
            _ent.Add(_world.NewEntity());
        }
    }
}
