using SummerSchoolGUI.Domain.ValueObjects;
using SummerSchoolGUI.Infrastructure;
using SummerSchoolGUI.Infrastructure.Services;
using System.ComponentModel;

namespace SummerSchoolGUI.ViewModels.Components;

public class TransformViewModel : ComponentViewModelBase
{
    public string Name => "TransformComponent";

    private TransformComponent TransformComponent { get { return (TransformComponent)_component; } }

    #region transform getters/setters
    public string PosX
    {
        get { return TransformComponent.posX.ToString(); }
        set
        {
            if (value == "")
                TransformComponent.posX = 0;
            else
                TransformComponent.posX = float.Parse(value);
            UpdateInternal(nameof(PosX));
        }
    }

    public string PosY
    {
        get => TransformComponent.posY.ToString();
        set
        {
            if (value == "")
                TransformComponent.posY = 0;
            else
                TransformComponent.posY = float.Parse(value);
            UpdateInternal(nameof(PosY));
        }
    }

    public string RotX
    {
        get => TransformComponent.rotX.ToString();
        set
        {
            if (value == "")
                TransformComponent.rotX = 0;
            else
                TransformComponent.rotX = float.Parse(value);
            UpdateInternal(nameof(RotX));
        }
    }

    public string RotY
    {
        get => TransformComponent.rotY.ToString();
        set
        {
            if (value == "")
                TransformComponent.rotY = 0;
            else
                TransformComponent.rotY = float.Parse(value);
            UpdateInternal(nameof(RotY));
        }
    }

    public string ScaleX
    {
        get => TransformComponent.scaleX.ToString();
        set
        {
            if (value == "")
                TransformComponent.scaleX = 0;
            else
                TransformComponent.scaleX = float.Parse(value);
            UpdateInternal(nameof(ScaleX));
        }
    }

    public string ScaleY
    {
        get => TransformComponent.scaleY.ToString();
        set
        {
            if (value == "")
                TransformComponent.scaleY = 0;
            else
                TransformComponent.scaleY = float.Parse(value);
            UpdateInternal(nameof(ScaleY));
        }
    }
    #endregion

    protected override void UpdateValues(Domain.ValueObjects.IComponent component)
    {
        _component = component;
        OnPropertyChanged(nameof(PosX));
        OnPropertyChanged(nameof(PosY));
        OnPropertyChanged(nameof(RotX));
        OnPropertyChanged(nameof(RotY));
        OnPropertyChanged(nameof(ScaleX));
        OnPropertyChanged(nameof(ScaleY));
    }

    public TransformViewModel() : base()
    {
        _component = new TransformComponent();
    }

    public TransformViewModel(IServiceProvider serviceProvider, TransformComponent component) : base(serviceProvider, component)
    {
    }
}
