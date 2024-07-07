using SummerSchoolGUI.Infrastructure.Services;

namespace SummerSchoolGUI.Infrastructure
{
    public static class GUIAPI
    {
        private static List<IService> services = new List<IService>();

        public static bool Initialized { get; set; } = false;
        public static T GetService<T>()
        {
            foreach (IService service in services)
            {
                if (service is T new_service)
                {

                    return new_service;
                }
            }
            return default(T);
        }

        public static void RegisterService(IService service)
        {
            services.Add(service);
        }
    }
}
