using ReactiveUI;
using System.Collections.ObjectModel;
using SummerSchoolGUI.Views;
using System.Collections.Generic;
using Avalonia.Controls;
using SummerSchoolGUI.Domain.ValueObjects;
using System.ComponentModel;
using SummerSchoolGUI.Infrastructure;
using SummerSchoolGUI.Infrastructure.Services;

namespace SummerSchoolGUI.ViewModels;

public class TransformViewModel : ViewModelBase
{
    public string Name => "TransformComponent";
    private TransformComponent _transformComponent;

    #region transform getters/setters
    public string PosX
    {
        get {return _transformComponent.posX.ToString(); }
        set {
            if (value == "")
                _transformComponent.posX = 0;
            else
                _transformComponent.posX = float.Parse(value);
            OnPropertyChanged(nameof(PosX));
             }
    }

    public string PosY
    {
        get => _transformComponent.posY.ToString();
        set {
            if (value == "")
                _transformComponent.posY = 0;
            else
                _transformComponent.posY = float.Parse(value);
            OnPropertyChanged(nameof(PosY));
             }
    }

    public string RotX
    {
        get => _transformComponent.rotX.ToString();
        set {
            if (value == "")
                _transformComponent.rotX = 0;
            else
                _transformComponent.rotX = float.Parse(value);
            OnPropertyChanged(nameof(RotX));
            }
    }

    public string RotY
    {
        get => _transformComponent.rotY.ToString();
        set {
            if (value == "")
                _transformComponent.rotY = 0;
            else
                _transformComponent.rotY = float.Parse(value);
            OnPropertyChanged(nameof(RotY));
             }
    }

    public string ScaleX
    {
        get => _transformComponent.scaleX.ToString();
        set {
            if (value == "")
                _transformComponent.scaleX = 0;
            else
                _transformComponent.scaleX = float.Parse(value);
            OnPropertyChanged(nameof(ScaleX));
             }
    }

    public string ScaleY
    {
        get => _transformComponent.scaleY.ToString();
        set {
            if (value == "")
                _transformComponent.scaleY = 0;
            else
                _transformComponent.scaleY = float.Parse(value);
            OnPropertyChanged(nameof(ScaleY));
             }
    }
    #endregion

    public TransformViewModel()
    {
        _transformComponent = new();
    }

    public TransformViewModel(IServiceProvider serviceProvider, TransformComponent component)
    {
        _transformComponent = component;
        MemoryAccessor memory = serviceProvider.GetService<MemoryAccessor>();
        PropertyChanged += (object sender, PropertyChangedEventArgs args) =>
        {
            memory.UpdateSelectedEntityComponent(_transformComponent);
        };
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
