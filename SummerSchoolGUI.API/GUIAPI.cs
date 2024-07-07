﻿using SummerSchoolGUI.Infrastructure.Services;

namespace SummerSchoolGUI.API
{
    public static class GUIAPI
    {
        private static List<IService> services = new List<IService>();

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

        private static void RegisterService(IService service)
        {
            services.Add(service);
        }
    }
}
