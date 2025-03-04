using System;
using GtMotive.Estimate.Microservice.Domain.Attributes;
using GtMotive.Estimate.Microservice.Domain.Common;

namespace GtMotive.Estimate.Microservice.Domain.Vehicle
{
    /// <summary>
    /// Represents a vehicle entity in the system.
    /// </summary>
    [BsonCollection("Vehicles")]
    public class Vehicle : IDocument
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

        /// <summary>
        /// Gets or sets the user who created the vehicle record.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user who last modified the vehicle record.
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the vehicle.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets the date and time when the vehicle record was created.
        /// </summary>
        public DateTime CreatedAt { get; }

        /// <summary>
        /// Gets or sets the date and time when the vehicle record was last modified.
        /// </summary>
        public DateTime ModifiedAt { get; set; }
    }
}
