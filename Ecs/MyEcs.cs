using System;
using Leopotam.EcsLite;
using MyEngine.Ecs.Systems;
using SummerSchoolGUI.Domain.ValueObjects;
using SummerSchoolGUI.Infrastructure;
using SummerSchoolGUI.Infrastructure.Services;

namespace MyEngine.Ecs
{
    public class MyEcs
    {
        private EcsWorld _world;
        private IEcsSystems _systems;
        private CoreObserver _observer;
        private List<Entity> _ent;
        public MyEcs()
        {
            _observer = GUIAPI.GetService<CoreObserver>();
            _ent = new List<Entity>();

            _world = new EcsWorld();
            _systems = new EcsSystems(_world, _ent);
            _systems
                .Add(new CreationSystem())
                .Add(new MovementSystem())
                .Add(new OutputSystem())
                .Init();

            // здесь у нас уже буду заданы сущности
            _observer = GUIAPI.GetService<CoreObserver>();


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
