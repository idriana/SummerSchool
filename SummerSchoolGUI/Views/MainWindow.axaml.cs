using Avalonia.Controls;
using SummerSchoolGUI.ViewModels;
using System.ComponentModel;

namespace SummerSchoolGUI.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Closing += OnClosing;
    }

    protected void OnClosing(object? sender, WindowClosingEventArgs e)
    {
        if (DataContext is MainViewModel viewModel)
        {
            viewModel.OnWindowClosing();
        }
    }
}
