using Microsoft.Extensions.DependencyInjection;

namespace OddEvenTriangleSum.Application
{
    public class Program
    {
        static void Main()
        {
            var servicesProvider = ServiceRegistration
                .RegisterServices()
                .BuildServiceProvider();

            servicesProvider.GetService<App>().Run();
        }
    }
}
