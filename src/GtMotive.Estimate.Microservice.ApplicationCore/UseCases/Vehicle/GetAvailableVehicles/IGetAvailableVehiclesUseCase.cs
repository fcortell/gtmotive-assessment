using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle.GetAvailableVehicles
{
    public interface IGetAvailableVehiclesUseCase
    {
        Task<GetAvailableVehiclesOutput> Execute();
    }
}
