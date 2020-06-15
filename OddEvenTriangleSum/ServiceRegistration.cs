using Microsoft.Extensions.DependencyInjection;
using OddEvenTriangleSum.Application;

namespace OddEvenTriangleSum
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterServices()
        {
            var services = new ServiceCollection()
            .AddSingleton<ITriangleWorker, TriangleWorker>()
            .AddSingleton<IFileReader, FileReader>()
            .AddSingleton<App>();
            return services;
        }
    }
}
