using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummerSchoolGUI.Infrastructure.Services;

namespace SummerSchoolGUI.Infrastructure
{
    public class ServiceProvider : IServiceProvider
    {
        private List<IService> services = new List<IService>();

        public T GetService<T>()
        {
            foreach (IService service in services)
            {
                if ( service is T new_service)
                {
                    return new_service;
                }
            }
            return default(T);
        }

        public void RegisterService(IService service)
        {
            services.Add(service);
        }
    }
}
