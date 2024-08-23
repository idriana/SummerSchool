﻿using System;
using Leopotam.EcsLite;
using MyEngine.Ecs.Components;
using MyEngine.Ecs.Components.Primitives;

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

            world.GetPool<PrimitiveModel>().Add(e1);
            ref PrimitiveModel primitive = ref world.GetPool<PrimitiveModel>().Get(e1);
            primitive.Fill = true;
            primitive.Shape = new Circle() { Center = new System.Numerics.Vector2(0, 0), Radius = 10 };

            int e = CreateEntity(systems);
            world.GetPool<WorldBox>().Add(e);
            ref WorldBox wb = ref world.GetPool<WorldBox>().Get(e);
            wb.left = 0;
            wb.right = 400;
            wb.top = 0;
            wb.bottom = 400;

            world.GetPool<PrimitiveModel>().Add(e);
            ref PrimitiveModel primitive1 = ref world.GetPool<PrimitiveModel>().Get(e1);
            primitive.Fill = false;
            primitive.Shape = new Rectangle() { TopLeft = wb.TopLeft, BottomRight = wb.BottomRight };
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
