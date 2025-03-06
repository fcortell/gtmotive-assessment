using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle.GetAvailableVehicles
{
    /// <summary>
    /// Represents the output of the GetAvailableVehicles use case.
    /// </summary>
    public class GetAvailableVehiclesOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAvailableVehiclesOutput"/> class.
        /// </summary>
        /// <param name="vehicles">The collection of available vehicles.</param>
        public GetAvailableVehiclesOutput(IEnumerable<Domain.Vehicle.Vehicle> vehicles)
        {
            Vehicles = vehicles;
        }

        /// <summary>
        /// Gets the collection of available vehicles.
        /// </summary>
        public IEnumerable<Domain.Vehicle.Vehicle> Vehicles { get; }
    }
}
