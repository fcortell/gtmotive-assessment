// <copyright file="RegisterVehicleOutput.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
/// <summary>
/// Represents the output of the Register Vehicle use case.
/// </summary>
namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle.RegisterVehicle
{
    /// <summary>
    /// The output data structure for the Register Vehicle use case.
    /// </summary>
    public class RegisterVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterVehicleOutput"/> class.
        /// </summary>
        /// <param name="vehicleId">The unique identifier of the registered vehicle.</param>
        public RegisterVehicleOutput(string vehicleId)
        {
            VehicleId = vehicleId;
        }

        /// <summary>
        /// Gets or sets the unique identifier of the registered vehicle.
        /// </summary>
        public string VehicleId { get; set; }
    }
}
