using Avalonia.Controls;
using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SummerSchoolGUI.Domain.ValueObjects;
using SummerSchoolGUI.Views;
using System.Diagnostics;
using SummerSchoolGUI.Infrastructure;
using SummerSchoolGUI.Infrastructure.Services;

namespace SummerSchoolGUI.ViewModels;

public class ComponentsViewModel : ViewModelBase
{
    private IServiceProvider ServiceProvider;
    /// <summary>
    /// Currently displayed components
    /// </summary>
    private List<IComponent> components = new();
    
    /// <summary>
    /// ViewModels for displayed components
    /// </summary>
    private List<ViewModelBase> viewModels = new List<ViewModelBase>();

    /// <summary>
    /// View name
    /// </summary>
    public string Name => "Components";

    /// <summary>
    /// Views for displayed components
    /// </summary>
    public ObservableCollection<UserControl> PropertyViews { get; set; } = new ObservableCollection<UserControl>();

    /// <summary>
    /// Designer only constructor
    /// </summary>
    public ComponentsViewModel()
    {
        components.Add(new TransformComponent());
        components.Add(new TransformComponent());
        viewModels.Add(new TransformViewModel());
        viewModels.Add(new TransformViewModel());
        PropertyViews.Add(new TransformView() { DataContext = viewModels[0] });
        PropertyViews.Add(new TransformView() { DataContext = viewModels[1] });
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="serviceProvider"> Provider for application sevices</param>
    public ComponentsViewModel(IServiceProvider serviceProvider)
    {
        this.ServiceProvider = serviceProvider;
        MemoryAccessor memory = serviceProvider.GetService<MemoryAccessor>();
        components = memory.Entity.components;
        memory.SelectedEntityUpdated += OnSelectedEntityUpdated;
        CreateModels(serviceProvider);
        CreateViews(serviceProvider);
    }

    private void OnSelectedEntityUpdated(object sender, Entity entity)
    {
        this.components = entity.components;
        CreateModels(this.ServiceProvider);
        CreateViews(this.ServiceProvider);
    }

    /// <summary>
    /// Creates ViewModels for displayed components.
    /// </summary>
    public void CreateModels(IServiceProvider serviceProvider)
    {
        viewModels = new();
        for (int i = 0; i < components.Count; i++)
        {
            if (components[i] is TransformComponent transformComponent) 
            {
                viewModels.Add(new TransformViewModel(serviceProvider, transformComponent));
            }
            else
            {
                Debug.WriteLine("Can't create view model for component!");
            }
        }
    }

    /// <summary>
    /// Creates Views for displayed components.
    /// </summary>
    public void CreateViews(IServiceProvider serviceProvider)
    {
        PropertyViews = new();
        for (int i = 0; i < viewModels.Count; i++)
        {
            if (viewModels[i] is TransformViewModel transformViewModel)
            {
                PropertyViews.Add(new TransformView() { DataContext = transformViewModel });
            }
            else
            {
                Debug.WriteLine("Can't create view for view model!");
            }
        }
    }
}

