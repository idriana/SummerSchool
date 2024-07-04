

using SummerSchoolGUI.Infrastructure.Services;

namespace SummerSchoolGUI.API
{
    public static class GUIAPI
    {
        public static List<IService> services;

        public static T GetService<T>()
        {
            if (services == null)
            {
                CreateServices();
            }

            foreach (IService service in services)
            {
                if (service is T new_service)
                {
                    return new_service;
                }
            }
            return default(T);
        }

        private static void CreateServices()
        {
            services = new List<IService>();
            services.Add(new GUIObserver());
            services.Add(new CoreObserver());
        }
    }
}
