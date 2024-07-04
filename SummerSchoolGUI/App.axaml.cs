using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using SummerSchoolGUI.ViewModels;
using SummerSchoolGUI.Views;
using SummerSchoolGUI.Infrastructure;
using SummerSchoolGUI.Infrastructure.Services;
using SummerSchoolGUI.API;

namespace SummerSchoolGUI;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel(InitializeServices())
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel(InitializeServices())
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private IServiceProvider InitializeServices()
    {
        IServiceProvider serviceProvider = new ServiceProvider();
        serviceProvider.RegisterService(new MemoryAccessor());
        serviceProvider.RegisterService(GUIAPI.GetService<GUIObserver>());
        serviceProvider.RegisterService(GUIAPI.GetService<CoreObserver>());
        return serviceProvider;
    }
}
