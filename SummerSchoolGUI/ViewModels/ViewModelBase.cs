using ReactiveUI;
using System.ComponentModel;
using SummerSchoolGUI.Infrastructure;
using SummerSchoolGUI.Infrastructure.Services;
using Commands.GameCommands;
using SummerSchoolGUI.Domain.ValueObjects;
using System.Collections.Generic;


namespace SummerSchoolGUI.ViewModels;

public class ViewModelBase : ReactiveObject
{
    protected IServiceProvider serviceProvider;

    protected ViewModelBase(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    protected ViewModelBase()
    {

    }
}
