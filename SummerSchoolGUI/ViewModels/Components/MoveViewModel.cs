using Avalonia.Controls;
using SummerSchoolGUI.Domain.ValueObjects;
using SummerSchoolGUI.Infrastructure.Services;
using SummerSchoolGUI.ViewModels.Primitives;
using SummerSchoolGUI.Views.Primitives;
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

        public UserControl Vector { get; private set; }

        private MoveComponent MoveComponent { get { return (MoveComponent)_component; } }

        public MoveViewModel() : base()
        {
            _component = new MoveComponent();
            Vector = new Vector2View() { DataContext = new Vector2ViewModel()};
        }

        public MoveViewModel(Infrastructure.IServiceProvider serviceProvider, MoveComponent component) : base(serviceProvider, component) 
        {
            Vector2ViewModel VelocityVM = new Vector2ViewModel("Velocity", serviceProvider);
            Vector = new Vector2View() { DataContext = VelocityVM };

            VelocityVM.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "X")
                {
                    MoveComponent.dx = VelocityVM.GetX();
                    UpdateTemp();
                }
                if (args.PropertyName == "Y")
                {
                    MoveComponent.dy = VelocityVM.GetY();
                    UpdateTemp();
                }
            };

            VelocityVM.SetX(component.dx);
            VelocityVM.SetY(component.dy);
        }

        protected override void UpdateValues(Domain.ValueObjects.IComponent component)
        {
            if (component is MoveComponent moveComponent) {
                Vector2ViewModel? VelocityVM = Vector.DataContext as Vector2ViewModel;
                VelocityVM?.SetX(moveComponent.dx);
                VelocityVM?.SetY(moveComponent.dy);
            }
            else
            {
                throw new ArgumentException($"Expected component of type {typeof(MoveComponent)}, got component of type {component.GetType()}");
            }
        }
    }
}
