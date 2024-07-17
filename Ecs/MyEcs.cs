using System;
using Leopotam.EcsLite;
using MyEngine.Ecs.Systems;

namespace MyEngine.Ecs
{
    public class MyEcs
    {
        private EcsWorld _world;
        private IEcsSystems _systems;
        public MyEcs()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
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
    }
}
