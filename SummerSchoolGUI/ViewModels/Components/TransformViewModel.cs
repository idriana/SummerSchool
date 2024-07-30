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
            PositionVM.SetValue(transformComponent.Position);

            Vector2ViewModel RotationVM = Rotation.DataContext as Vector2ViewModel;
            RotationVM.SetValue(transformComponent.Rotation);

            Vector2ViewModel ScaleVM = Scale.DataContext as Vector2ViewModel;
            ScaleVM.SetValue(transformComponent.Scale);
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
            TransformComponent.Position = PositionVM.GetValue();
            UpdateTemp();
        };

        RotationVM.PropertyChanged += (sender, args) =>
        {
            TransformComponent.Rotation = RotationVM.GetValue();
            UpdateTemp();
        };

        ScaleVM.PropertyChanged += (sender, args) =>
        {
            TransformComponent.Scale = ScaleVM.GetValue();
            UpdateTemp();
        };

        PositionVM.SetValue(component.Position);
        RotationVM.SetValue(component.Rotation);
        ScaleVM.SetValue(component.Scale);
    }
}
