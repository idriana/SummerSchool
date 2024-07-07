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
        public T GetService<T>();

        public void RegisterService(IService service);
    }
}
