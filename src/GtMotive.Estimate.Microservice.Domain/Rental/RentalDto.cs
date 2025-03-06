using System;

namespace GtMotive.Estimate.Microservice.Domain.Rental
{
    /// <summary>
    /// Represents a rental DTO.
    /// </summary>
    ///
    public class RentalDto
    {
        /// <summary>
        /// Gets or sets the ID of the customer renting the vehicle.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the vehicle being rented.
        /// </summary>
        ///
        public string VehicleId { get; set; }

        /// <summary>
        /// Gets or sets the start date of the rental period.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the rental period.
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the comments for the rental.
        /// </summary>
        public string Comment { get; set; }
    }
}
