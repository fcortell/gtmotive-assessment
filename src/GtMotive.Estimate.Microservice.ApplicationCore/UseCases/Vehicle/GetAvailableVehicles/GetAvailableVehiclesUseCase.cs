using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Vehicle;
using MongoDB.Driver.Linq;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle.GetAvailableVehicles
{
    /// <summary>
    /// Use case for retrieving available vehicles.
    /// </summary>
    public class GetAvailableVehiclesUseCase : IGetAvailableVehiclesUseCase
    {
        private readonly IVehicleRepository _vehicleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAvailableVehiclesUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">The vehicle repository.</param>
        public GetAvailableVehiclesUseCase(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        /// <summary>
        /// Executes the use case to get available vehicles.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the output with available vehicles.</returns>
        public async Task<GetAvailableVehiclesOutput> Execute()
        {
            // Retrieve available vehicles from the repository
            var availableVehicles = await _vehicleRepository.AsQueryable().Where(x => x.IsAvailable).ToListAsync();

            // Create output with the retrieved vehicles
            var output = new GetAvailableVehiclesOutput(availableVehicles);

            return output;
        }
    }
}
