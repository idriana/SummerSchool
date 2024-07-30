using SummerSchoolGUI.Domain.ValueObjects;
using SummerSchoolGUI.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerSchoolGUI.ViewModels.Primitives
{
    public abstract class PrimitiveViewModelBase : ViewModelBase, INotifyPropertyChanged
    {
        protected PrimitiveViewModelBase(Infrastructure.IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        protected PrimitiveViewModelBase() : base()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
