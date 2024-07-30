using SummerSchoolGUI.Domain.ValueObjects;
using SummerSchoolGUI.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace SummerSchoolGUI.ViewModels.Primitives
{
    public class FloatViewModel : PrimitiveViewModelBase
    {
        public string PropertyName { get; private set; }

        private float _value;
        public string Value
        {
            get
            { 
                return _value.ToString(); 
            }
            set
            {
                if (value == "")
                    _value = 0;
                else
                    _value = float.Parse(value);
                OnPropertyChanged(nameof(Value));
            }
        }

        public float GetValue()
        {
            return _value;
        }

        public void SetValue(float value)
        {
            _value = value;
            OnPropertyChanged(nameof(Value));
        }

        public FloatViewModel() : base()
        {
            PropertyName = "Float";
        }

        public FloatViewModel(string propertyName, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            PropertyName = propertyName;
        }
    }
}
