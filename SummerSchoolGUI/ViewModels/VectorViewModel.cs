using ReactiveUI;
using SummerSchoolGUI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace SummerSchoolGUI.ViewModels;

public class VectorViewModel : ViewModelBase
{
    public string Name { get; set; } = "Vector";
    private List<float> values = new List<float>();
    private List<FloatViewModel> viewModels;
    public ObservableCollection<FloatView> views { get; set; } = new ObservableCollection<FloatView>();

    public VectorViewModel()
    {
        this.values = new List<float>() { 0f, 0f };
        CreateModels();
        CreateViews();
    }

    public VectorViewModel(List<float> values)
    {
        this.values = values;
        CreateModels();
        CreateViews();
    }

    public void CreateModels()
    {
        viewModels = new List<FloatViewModel>();
        for (int i = 0; i < values.Count; i++) 
        {
            viewModels.Add(new FloatViewModel());
        }
    }

    public void CreateViews()
    {
        views = new ObservableCollection<FloatView>();
        for (int i = 0; i < viewModels.Count; i++)
        {
            views.Add(new FloatView() { DataContext = viewModels[i] });
        }
    
    }
}
