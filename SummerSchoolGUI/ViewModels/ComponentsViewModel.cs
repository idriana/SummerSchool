using Avalonia.Controls;
using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SummerSchoolGUI.Domain.ValueObjects;
using SummerSchoolGUI.Views;
using System.Diagnostics;
using SummerSchoolGUI.Infrastructure;
using SummerSchoolGUI.Infrastructure.Services;
using SummerSchoolGUI.ViewModels.Components;

namespace SummerSchoolGUI.ViewModels;

public class ComponentsViewModel : ViewModelBase
{
    /// <summary>
    /// Currently displayed components
    /// </summary>
    private List<Domain.ValueObjects.IComponent> components = new();
    
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
    public ComponentsViewModel() : base()
    {
        components.Add(new TransformComponent());
        components.Add(new MoveComponent());
        viewModels.Add(new TransformViewModel());
        viewModels.Add(new MoveViewModel());
        PropertyViews.Add(new TransformView() { DataContext = viewModels[0] });
        PropertyViews.Add(new MoveView() { DataContext = viewModels[1] });
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="serviceProvider"> Provider for application sevices</param>
    public ComponentsViewModel(Infrastructure.IServiceProvider serviceProvider) : base(serviceProvider)
    {
        MemoryAccessor memory = serviceProvider.GetService<MemoryAccessor>();
        components = memory.Entity?.components;
        memory.SelectedEntityUpdated += OnSelectedEntityUpdated;
        CreateModels(serviceProvider);
        CreateViews(serviceProvider);
    }

    private void OnSelectedEntityUpdated(object sender, Entity entity)
    {
        this.components = entity.components;
        CreateModels(this.serviceProvider);
        CreateViews(this.serviceProvider);
    }

    /// <summary>
    /// Creates ViewModels for displayed components.
    /// </summary>
    private void CreateModels(Infrastructure.IServiceProvider serviceProvider)
    {
        viewModels.Clear();
        for (int i = 0; i < components?.Count; i++)
        {
            if (components[i] is TransformComponent transformComponent) 
            {
                viewModels.Add(new TransformViewModel(serviceProvider, transformComponent));
            }
            else if (components[i] is MoveComponent moveComponent)
            {
                viewModels.Add(new MoveViewModel(serviceProvider, moveComponent));
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
    private void CreateViews(Infrastructure.IServiceProvider serviceProvider)
    {
        PropertyViews.Clear();
        for (int i = 0; i < viewModels?.Count; i++)
        {
            if (viewModels[i] is TransformViewModel transformViewModel)
            {
                PropertyViews.Add(new TransformView() { DataContext = transformViewModel });
            }
            else if (viewModels[i] is MoveViewModel moveViewModel)
            {
                PropertyViews.Add(new MoveView() { DataContext = moveViewModel });
            }
            else
            {
                Debug.WriteLine("Can't create view for view model!");
            }
        }
    }
}

