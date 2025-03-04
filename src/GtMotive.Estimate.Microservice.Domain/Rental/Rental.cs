using System;
using GtMotive.Estimate.Microservice.Domain.Attributes;
using GtMotive.Estimate.Microservice.Domain.Common;

namespace GtMotive.Estimate.Microservice.Domain.Rental
{
    /// <summary>
    /// Represents a rental entity.
    /// </summary>
    ///
    [BsonCollection("Rentals")]
    public class Rental : IDocument
    {
        /// <summary>
        /// Gets or sets the ID of the customer renting the vehicle.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the vehicle being rented.
        /// </summary>
        public string VehicleId { get; set; }

        /// <summary>
        /// Gets or sets the start date of the rental period.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the rental period.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the rental.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets the date and time when the rental was created.
        /// </summary>
        public DateTime CreatedAt { get; }

        /// <summary>
        /// Gets or sets the date and time when the rental was last modified.
        /// </summary>
        public DateTime ModifiedAt { get; set; }

        /// <summary>
        /// Gets or sets the comments for the rental.
        /// </summary>
        public string Comment { get; set; }
    }
}
