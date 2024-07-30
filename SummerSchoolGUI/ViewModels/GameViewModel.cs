using SummerSchoolGUI.Infrastructure;
using System.Collections.Generic;
using SummerSchoolGUI.Domain.ValueObjects;
using SummerSchoolGUI.Infrastructure.Services;
using System.Collections.ObjectModel;
using System.Numerics;
using Presentation;
using Commands.GameCommands;
using System;

namespace SummerSchoolGUI.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        public List<Entity> Entities { get; set; }

        public ObservableCollection<EntityPresentation> EntityPresentations { get; set; } = new();

        /// <summary>
        /// Designer only constructor
        /// </summary>
        public GameViewModel() : base()
        {
            Entities = new ();
            Entities.Add(new Entity(0));
            Entities.Add(new Entity(1));
            Entities[0].components.Add(new TransformComponent() { Position = new Vector2(100, 100)});
            Entities[1].components.Add(new TransformComponent() {Position = new Vector2(200, 200) });
            CreatePresentations();
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="serviceProvider"> Provider for application services. </param>
        public GameViewModel(Infrastructure.IServiceProvider serviceProvider) : base(serviceProvider)
        {
            MemoryAccessor memory = serviceProvider.GetService<MemoryAccessor>();
            Entities = new List<Entity>(memory.Entities);
            memory.PresentationChanged += OnEntityCollectionUpdated;
            CreatePresentations();
        }

        private void OnEntityCollectionUpdated(object sender, EventArgs args)
        {
            Entities = serviceProvider.GetService<MemoryAccessor>().Entities;
            CreatePresentations();
        }

        private void CreatePresentations()
        {
            EntityPresentations.Clear();
            foreach (var entity in Entities)
            {
                TransformComponent transform = entity.Transform;
                EntityPresentations.Add(
                    new EntityPresentation(
                    transform.Position.X,
                    transform.Position.Y,
                    transform.Rotation.X,
                    transform.Rotation.Y,
                    transform.Scale.X,
                    transform.Scale.Y)
                );
            }
        }
    }
}
