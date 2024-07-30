using Avalonia.Controls;
using SummerSchoolGUI.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerSchoolGUI.ViewModels.Primitives
{
    public class Vector2ViewModel : PrimitiveViewModelBase
    {
        public string PropertyName { get; private set; }

        public UserControl X { get; private set; }
        public UserControl Y { get; private set; }

        public Vector2ViewModel() : base() 
        {
            PropertyName = "Vector2";
            X = new FloatView() { DataContext = new FloatViewModel()};
            Y = new FloatView() { DataContext = new FloatViewModel()};
        }

        public Vector2ViewModel(string propertyName, IServiceProvider serviceProvider) : base(serviceProvider) 
        {
            PropertyName = propertyName;
            FloatViewModel Xvm = new FloatViewModel("X", serviceProvider);
            FloatViewModel Yvm = new FloatViewModel("Y", serviceProvider);

            X = new FloatView() { DataContext = Xvm };
            Y = new FloatView() { DataContext = Yvm };

            Xvm.PropertyChanged += (sender, args) => OnPropertyChanged(nameof(X));
            Yvm.PropertyChanged += (sender, args) => OnPropertyChanged(nameof(Y));
        }

        public float GetX()
        {
            FloatViewModel FloatVM = X.DataContext as FloatViewModel;
            return FloatVM.GetValue();
        }

        public float GetY()
        {
            FloatViewModel FloatVM = Y.DataContext as FloatViewModel;
            return FloatVM.GetValue();
        }

        public void SetX(float value)
        {
            FloatViewModel FloatVM = X.DataContext as FloatViewModel;
            FloatVM.SetValue(value);
        }

        public void SetY(float value)
        {
            FloatViewModel FloatVM = Y.DataContext as FloatViewModel;
            FloatVM.SetValue(value);
        }
    }
}
