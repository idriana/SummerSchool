using ReactiveUI;

namespace SummerSchoolGUI.ViewModels;

public class FloatViewModel : ViewModelBase
{
    private float _value = 0f;

    public string Name { get; set; } = "X";

    public string StringValue
    {
        get { return _value.ToString(); }
        set { _value = float.Parse(value); }
    }
}
