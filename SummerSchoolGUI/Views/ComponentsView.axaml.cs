using Avalonia.Controls;
using SummerSchoolGUI.ViewModels;

namespace SummerSchoolGUI.Views
{
    public partial class ComponentsView : UserControl
    {
        public ComponentsView()
        {
            InitializeComponent();
            DataContext = new ComponentsViewModel();
        }
    }
}
