using SummerSchoolGUI.Views;
using SummerSchoolGUI.Infrastructure;
using SummerSchoolGUI.Infrastructure.Services;

namespace SummerSchoolGUI.ViewModels;

public class MainViewModel : ViewModelBase
{
    private IServiceProvider serviceProvider;

    /// <summary>
    /// Debug string
    /// </summary>
    public string Greeting => "Welcome to Avalonia!";

    /// <summary>
    /// View of the game
    /// </summary>
    public GameView GameView { get; private set; }

    /// <summary>
    /// View of selected entity components
    /// </summary>
    public ComponentsView ComponentsView { get; private set; }

    /// <summary>
    /// Design only constructor
    /// </summary>
    public MainViewModel()
    {
        GameView = new GameView() { DataContext = new GameViewModel() };
        ComponentsView = new ComponentsView() {  DataContext = new ComponentsViewModel() };
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="serviceProvider"> Provider for application services </param>
    public MainViewModel(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        GameView = new GameView() { DataContext = new GameViewModel(serviceProvider) };
        ComponentsView = new ComponentsView() { DataContext = new ComponentsViewModel(serviceProvider) };
    }

    public void OnWindowClosing()
    {
        GUIObserver observer = serviceProvider.GetService<GUIObserver>();
    }
}
