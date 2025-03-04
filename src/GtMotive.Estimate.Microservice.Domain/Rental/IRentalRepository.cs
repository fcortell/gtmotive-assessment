using GtMotive.Estimate.Microservice.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Domain.Rental
{
    /// <summary>
    /// Interface for the Rental repository, providing methods to interact with rental data in the MongoDB.
    /// </summary>
    public interface IRentalRepository : IMongoRepository<Rental>
    {
        /// <summary>
        /// Adds a new rental asynchronously.
        /// </summary>
        /// <param name="rental">The rental entity to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task AddAsync(Rental rental);

        /// <summary>
        /// Retrieves all rentals asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of rentals.</returns>
        Task<List<Rental>> GetAllAsync();

        /// <summary>
        /// Retrieves an active rental by the customer ID asynchronously.
        /// </summary>
        /// <param name="customerId">The ID of the customer.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the rental entity.</returns>
        Task<Rental> GetActiveRentalByCustomer(string customerId);

        /// <summary>
        /// Updates an existing rental asynchronously.
        /// </summary>
        /// <param name="rental">The rental entity to update.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task Update(Rental rental);

        /// <summary>
        /// Retrieves scheduled rentals for a specific vehicle within a date range asynchronously.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle.</param>
        /// <param name="startDate">The start date of the rental period.</param>
        /// <param name="endDate">The end date of the rental period.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of scheduled rentals.</returns>
        Task<List<Rental>> GetScheduledRentalsByVehicle(string vehicleId, DateTime startDate, DateTime endDate);
    }
}
