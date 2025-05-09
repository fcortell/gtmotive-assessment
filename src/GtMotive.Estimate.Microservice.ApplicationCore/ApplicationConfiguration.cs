﻿using System;
using System.Diagnostics.CodeAnalysis;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent.RentVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rental.CheckoutVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle.GetAvailableVehicles;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle.RegisterVehicle;
using Microsoft.Extensions.DependencyInjection;

[assembly: CLSCompliant(false)]

namespace GtMotive.Estimate.Microservice.ApplicationCore
{
    /// <summary>
    /// Adds Use Cases classes.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ApplicationConfiguration
    {
        /// <summary>
        /// Adds Use Cases to the ServiceCollection.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>The modified instance.</returns>
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IRentVehicleUseCase, RentVehicleUseCase>();
            services.AddScoped<IRegisterVehicleUseCase, RegisterVehicleUseCase>();
            services.AddScoped<ICheckoutVehicleUseCase, CheckoutVehicleUseCase>();
            services.AddScoped<IGetAvailableVehiclesUseCase, GetAvailableVehiclesUseCase>();
            return services;
        }
    }
}
