using Commands.GameCommands;
using SummerSchoolGUI.Domain.ValueObjects;
using SummerSchoolGUI.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerSchoolGUI.ViewModels.Components
{
    public abstract class ComponentViewModelBase : ViewModelBase, INotifyPropertyChanged
    {
        protected Domain.ValueObjects.IComponent _component;

        protected virtual void SendUpdates()
        {
            MemoryAccessor memoryAccessor = serviceProvider.GetService<MemoryAccessor>();
            serviceProvider.GetService<GUIObserver>().AddCommand<EntityListCommand, List<Entity>>(memoryAccessor.Entities);
        }

        private void OnComponentUpdated(object sender, Domain.ValueObjects.IComponent component)
        {
            if (_component.GetType() == component.GetType())
            {
                UpdateValues(component);
            }
        }

        protected abstract void UpdateValues(Domain.ValueObjects.IComponent component);

        protected ComponentViewModelBase(Infrastructure.IServiceProvider serviceProvider, Domain.ValueObjects.IComponent component) : base(serviceProvider)
        {
            _component = component;
            MemoryAccessor memory = serviceProvider.GetService<MemoryAccessor>();
            memory.SelectedEntityComponentUpdated += OnComponentUpdated;
        }

        protected ComponentViewModelBase() : base()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void UpdateInternal()
        {
            MemoryAccessor memory = serviceProvider.GetService<MemoryAccessor>();
            memory.UpdateSelectedEntityComponent(_component);
            SendUpdates();
        }
    }
}
