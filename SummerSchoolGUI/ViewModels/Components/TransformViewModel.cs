using Avalonia.Controls;
using SummerSchoolGUI.Domain.ValueObjects;
using SummerSchoolGUI.Infrastructure;
using SummerSchoolGUI.Infrastructure.Services;
using SummerSchoolGUI.ViewModels.Primitives;
using SummerSchoolGUI.Views.Primitives;
using System.ComponentModel;

namespace SummerSchoolGUI.ViewModels.Components;

public class TransformViewModel : ComponentViewModelBase
{
    public string Name => "TransformComponent";

    private TransformComponent TransformComponent { get { return (TransformComponent)_component; } }

    public UserControl Position { get; private set; }
    public UserControl Rotation { get; private set; }
    public UserControl Scale { get; private set; }

    protected override void UpdateValues(Domain.ValueObjects.IComponent component)
    {
        if (component is TransformComponent transformComponent) {
            Vector2ViewModel PositionVM = Position.DataContext as Vector2ViewModel;
            PositionVM.SetX(transformComponent.posX);
            PositionVM.SetY(transformComponent.posY);

            Vector2ViewModel RotationVM = Rotation.DataContext as Vector2ViewModel;
            RotationVM.SetX(transformComponent.rotX);
            RotationVM.SetY(transformComponent.rotY);

            Vector2ViewModel ScaleVM = Scale.DataContext as Vector2ViewModel;
            ScaleVM.SetX(transformComponent.scaleX);
            ScaleVM.SetY(transformComponent.scaleY);
        }
    }

    public TransformViewModel() : base()
    {
        _component = new TransformComponent();
        Position = new Vector2View() { DataContext = new Vector2ViewModel(), Name = "Position" };
        Rotation = new Vector2View() { DataContext = new Vector2ViewModel(), Name = "Rotation" };
        Scale = new Vector2View() { DataContext = new Vector2ViewModel(), Name = "Scale" };
    }

    public TransformViewModel(IServiceProvider serviceProvider, TransformComponent component) : base(serviceProvider, component)
    {
        Vector2ViewModel PositionVM = new Vector2ViewModel("Position", serviceProvider);
        Vector2ViewModel RotationVM = new Vector2ViewModel("Rotation", serviceProvider);
        Vector2ViewModel ScaleVM = new Vector2ViewModel("Scale", serviceProvider);

        Position = new Vector2View() { DataContext = PositionVM };
        Rotation = new Vector2View() { DataContext = RotationVM };
        Scale = new Vector2View() { DataContext = ScaleVM };

        PositionVM.PropertyChanged += (sender, args) =>
        {
            TransformComponent.posX = PositionVM.GetX();
            TransformComponent.posY = PositionVM.GetY();
            UpdateTemp();
        };

        RotationVM.PropertyChanged += (sender, args) =>
        {
            TransformComponent.rotX = RotationVM.GetX();
            TransformComponent.rotY = RotationVM.GetY();
            UpdateTemp();
        };

        ScaleVM.PropertyChanged += (sender, args) =>
        {
            TransformComponent.scaleX = ScaleVM.GetX();
            TransformComponent.scaleY = ScaleVM.GetY();
            UpdateTemp();
        };

        PositionVM.SetX(component.posX);
        PositionVM.SetY(component.posY);
        RotationVM.SetX(component.rotX);
        RotationVM.SetY(component.rotY);
        ScaleVM.SetX(component.scaleX);
        ScaleVM.SetY(component.scaleY);
    }
}
