using FluentResults;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle.RegisterVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.RegisterVehicle
{
    public record RegisterVehicleCommand : IRequest<Result<RegisterVehicleOutput>>
    {
        /// <summary>
        /// Gets or sets the brand of the vehicle.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the model of the vehicle.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the license plate of the vehicle.
        /// </summary>
        public string LicensePlate { get; set; }

        /// <summary>
        /// Gets or sets the color of the vehicle.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the manufacturing year of the vehicle.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the description of the vehicle.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the rental price per day for the vehicle.
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
    }
}
