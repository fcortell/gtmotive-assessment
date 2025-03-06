using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Vehicle;
using MongoDB.Driver.Linq;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle.GetAvailableVehicles
{
    public class GetAvailableVehiclesUseCase : IGetAvailableVehiclesUseCase
    {
        private readonly IVehicleRepository _vehicleRepository;

        public GetAvailableVehiclesUseCase(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<GetAvailableVehiclesOutput> Execute()
        {
            var availableVehicles = await _vehicleRepository.AsQueryable().Where(x => x.IsAvailable).ToListAsync();

            var output = new GetAvailableVehiclesOutput(availableVehicles);

            return output;
        }
    }
}
