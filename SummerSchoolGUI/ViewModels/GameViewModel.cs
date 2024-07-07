using SummerSchoolGUI.Infrastructure;
using System.Collections.Generic;
using SummerSchoolGUI.Domain.ValueObjects;
using SummerSchoolGUI.Infrastructure.Services;
using System.Collections.ObjectModel;
using System.Numerics;
using Presentation;

namespace SummerSchoolGUI.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        private IServiceProvider serviceProvider;

        public List<Entity> Entities { get; set; }

        public ObservableCollection<EntityPresentation> EntityPresentations { get; set; } = new();

        /// <summary>
        /// Designer only constructor
        /// </summary>
        public GameViewModel() 
        {
            Entities = new ();
            Entities.Add(new Entity());
            Entities.Add(new Entity());
            Entities[0].components.Add(new TransformComponent() { posX = 100, posY = 100});
            Entities[1].components.Add(new TransformComponent() { posX = 200, posY = 200});
            CreatePresentations();
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="serviceProvider"> Provider for application services. </param>
        public GameViewModel(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            MemoryAccessor memory = serviceProvider.GetService<MemoryAccessor>();
            Entities = new List<Entity>(memory.Entities);
            memory.EntityCollectionUpdated += OnEntityCollectionUpdated;
            CreatePresentations();
        }

        private void OnEntityCollectionUpdated(object sender, List<Entity> entities)
        {
            Entities = entities;
            CreatePresentations();
            foreach (Entity e in entities)
            {
                e.Transform.posY += 1;
            }
            serviceProvider.GetService<GUIObserver>().AddData(entities);
        }

        private void CreatePresentations()
        {
            EntityPresentations.Clear();
            foreach (var entity in Entities)
            {
                TransformComponent transform = entity.Transform;
                EntityPresentations.Add(
                    new EntityPresentation(
                    transform.posX,
                    transform.posY,
                    transform.rotX,
                    transform.rotY,
                    transform.scaleX,
                    transform.scaleY)
                );
            }
        }
    }
}
