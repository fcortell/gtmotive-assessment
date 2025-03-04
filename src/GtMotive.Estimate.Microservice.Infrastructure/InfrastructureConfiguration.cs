using System;
using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Domain.Rental;
using GtMotive.Estimate.Microservice.Domain.Vehicle;
using GtMotive.Estimate.Microservice.Infrastructure.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.Logging;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using GtMotive.Estimate.Microservice.Infrastructure.Repositories;
using GtMotive.Estimate.Microservice.Infrastructure.Telemetry;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: CLSCompliant(false)]

namespace GtMotive.Estimate.Microservice.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        [ExcludeFromCodeCoverage]
        public static IInfrastructureBuilder AddBaseInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration,
            bool isDevelopment)
        {
            if (configuration != null)
            {
                var mongoSetting = configuration.GetSection("MongoDb");
                services.Configure<MongoDbSettings>(options => mongoSetting.Bind(options));
                services.AddSingleton<IMongoService, MongoService>();
            }

            services.AddTransient<IVehicleRepository, VehicleRepository>();
            services.AddTransient<IRentalRepository, RentalRepository>();
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            if (!isDevelopment)
            {
                services.AddScoped(typeof(ITelemetry), typeof(AppTelemetry));
            }
            else
            {
                services.AddScoped(typeof(ITelemetry), typeof(NoOpTelemetry));
            }

            return new InfrastructureBuilder(services);
        }

        private sealed class InfrastructureBuilder : IInfrastructureBuilder
        {
            public InfrastructureBuilder(IServiceCollection services)
            {
                Services = services;
            }

            public IServiceCollection Services { get; }
        }
    }
}
