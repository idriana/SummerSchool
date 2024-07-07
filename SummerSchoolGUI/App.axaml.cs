using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using SummerSchoolGUI.ViewModels;
using SummerSchoolGUI.Views;
using SummerSchoolGUI.Infrastructure;
using SummerSchoolGUI.Infrastructure.Services;
using Avalonia.Threading;
using System;

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

    private Infrastructure.IServiceProvider InitializeServices()
    {
        Action<Action> syncDelegate = SyncThreads;
        Infrastructure.IServiceProvider serviceProvider = new ServiceProvider();
        serviceProvider.RegisterService(new MemoryAccessor());

        CommandProvider commandProvider = new CommandProvider();
        GUIObserver gUIObserver = new GUIObserver(commandProvider);
        CoreObserver coreObserver = new CoreObserver(syncDelegate, commandProvider, new CommandHandler(serviceProvider));
        
        serviceProvider.RegisterService(gUIObserver);
        GUIAPI.RegisterService(gUIObserver);
        GUIAPI.RegisterService(coreObserver);
        GUIAPI.Initialized = true;
        return serviceProvider;
    }

    private void SyncThreads(Action action)
    {
        Dispatcher.UIThread.Post(action);
    }
}
