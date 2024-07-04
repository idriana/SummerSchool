using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummerSchoolGUI.Infrastructure.Services;

namespace SummerSchoolGUI.Infrastructure
{
    public interface IServiceProvider
    {
        public abstract T GetService<T>();

        public abstract void RegisterService(IService service);
    }
}
