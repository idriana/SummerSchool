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
    internal class MoveViewModel : ComponentViewModelBase
    {
        public string Name => "MoveComponent";

        private MoveComponent MoveComponent { get { return (MoveComponent)_component; } }

        public string Dx
        {
            get
            {
                return MoveComponent.dx.ToString();
            }
            set
            {
                if (value == "")
                    MoveComponent.dx = 0;
                else
                    MoveComponent.dx = float.Parse(value);
                UpdateInternal(nameof(Dx));
            }
        }

        public string Dy
        {
            get
            {
                return MoveComponent.dy.ToString();
            }
            set
            {
                if (value == "")
                    MoveComponent.dy = 0;
                else
                    MoveComponent.dy = float.Parse(value);
                UpdateInternal(nameof(Dy));
            }
        }

        

        public MoveViewModel() : base()
        {
            _component = new MoveComponent();
        }

        public MoveViewModel(Infrastructure.IServiceProvider serviceProvider, MoveComponent component) : base(serviceProvider, component) 
        {
        }

        protected override void UpdateValues(Domain.ValueObjects.IComponent component)
        {
            _component = component;
            OnPropertyChanged(nameof(Dx));
            OnPropertyChanged(nameof(Dy));
        }
    }
}
