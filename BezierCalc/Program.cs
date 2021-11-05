using System;
using Microsoft.Extensions.DependencyInjection;

namespace BezierCalc
{
    public class Program
    {
        private static IServiceProvider _serviceProvider;

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<IResultsWriter, ResultsWriter>();
            services.AddTransient<IPointsCalculator, PointsCalculator>();

            services.AddSingleton<Application>();

            _serviceProvider = services.BuildServiceProvider(true);
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }

        static void Main(string[] args)
        {
            RegisterServices();
            IServiceScope scope = _serviceProvider.CreateScope();
            Application consoleApplication = scope.ServiceProvider.GetRequiredService<Application>();
            consoleApplication.Run(args);
            DisposeServices();
        }
    }
}
