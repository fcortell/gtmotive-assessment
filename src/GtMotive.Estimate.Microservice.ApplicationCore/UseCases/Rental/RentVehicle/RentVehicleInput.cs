using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent.RentVehicle
{
    /// <summary>
    /// Represents the input data required to rent a vehicle.
    /// </summary>
    public class RentVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Gets or sets the ID of the vehicle to be rented.
        /// </summary>
        public string VehicleId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the customer renting the vehicle.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the start date of the rental period.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the rental period.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets any additional comments related to the rental.
        /// </summary>
        public string Comments { get; set; }
    }
}
