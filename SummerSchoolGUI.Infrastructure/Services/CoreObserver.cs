using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerSchoolGUI.Infrastructure.Services
{
    public class CoreObserver : IService
    {
        public event EventHandler Changed;
    }
}
