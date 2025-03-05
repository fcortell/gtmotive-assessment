using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle.RegisterVehicle
{
    /// <summary>
    /// Interface for the Register Vehicle use case.
    /// </summary>
    public interface IRegisterVehicleUseCase
    {
        /// <summary>
        /// Executes the Register Vehicle use case.
        /// </summary>
        /// <param name="input">The input data required to register a vehicle.</param>
        /// <param name="session">The MongoDB client session handle.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the output data of the registered vehicle.</returns>
        Task<RegisterVehicleOutput> Execute(RegisterVehicleInput input, IClientSessionHandle session, CancellationToken cancellationToken);
    }
}
