using Avalonia.Controls;
using SummerSchoolGUI.ViewModels;
using System.ComponentModel;

namespace SummerSchoolGUI.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        //DataContext = new MainViewModel();
    }
}
