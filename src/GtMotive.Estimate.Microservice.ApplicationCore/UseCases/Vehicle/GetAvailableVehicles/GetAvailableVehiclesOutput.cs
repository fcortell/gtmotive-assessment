using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle.GetAvailableVehicles
{
    public class GetAvailableVehiclesOutput : IUseCaseOutput
    {
        public GetAvailableVehiclesOutput(IEnumerable<Domain.Vehicle.Vehicle> vehicles)
        {
            Vehicles = vehicles;
        }

        public IEnumerable<Domain.Vehicle.Vehicle> Vehicles { get; }
    }
}
