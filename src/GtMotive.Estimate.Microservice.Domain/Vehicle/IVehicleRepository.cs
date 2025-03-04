using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.Domain.Vehicle
{
    /// <summary>
    /// Interface for the vehicle repository, providing methods for managing vehicle data in a MongoDB context.
    /// </summary>
    public interface IVehicleRepository : IMongoRepository<Vehicle>
    {
        /// <summary>
        /// Marks a vehicle as rented.
        /// </summary>
        /// <param name="id">The unique identifier of the vehicle.</param>
        /// <returns>A boolean indicating whether the operation was successful.</returns>
        bool MarkVehicleAsRented(string id);

        /// <summary>
        /// Marks a vehicle as available.
        /// </summary>
        /// <param name="id">The unique identifier of the vehicle.</param>
        /// <returns>A boolean indicating whether the operation was successful.</returns>
        bool MarkVehicleAsAvailable(string id);
    }
}
