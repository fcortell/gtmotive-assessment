// <copyright file="RegisterVehicleInput.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
/// <summary>
/// Represents the input data required to register a vehicle.
/// </summary>
namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle.RegisterVehicle
{
    /// <summary>
    /// Represents the input data required to register a vehicle.
    /// </summary>
    public class RegisterVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Gets or sets the license plate of the vehicle.
        /// </summary>
        public string LicensePlate { get; set; }

        /// <summary>
        /// Gets or sets the brand of the vehicle.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the model of the vehicle.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the color of the vehicle.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the year of the vehicle.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the price per day for renting the vehicle.
        /// </summary>
        public decimal PricePerDay { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the vehicle is available for rent.
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the vehicle is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the description of the vehicle.
        /// </summary>
        public string Description { get; set; }
    }
}
