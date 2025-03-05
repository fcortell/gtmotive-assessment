using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent.CheckoutVehicle;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rental.CheckoutVehicle
{
    public interface ICheckoutVehicleUseCase
    {
        Task<CheckoutVehicleOutput> Execute(CheckoutVehicleInput input, IClientSessionHandle session, CancellationToken cancellationToken);
    }
}
