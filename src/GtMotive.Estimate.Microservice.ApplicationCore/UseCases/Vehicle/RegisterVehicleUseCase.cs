using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Vehicle;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle.RegisterVehicle
{
    /// <summary>
    /// Use case for registering a new vehicle in the system.
    /// </summary>
    public class RegisterVehicleUseCase : IRegisterVehicleUseCase
    {
        private readonly IVehicleRepository _vehicleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterVehicleUseCase"/> class.
        /// </summary>
        /// <param name="vehicleRepository">The vehicle repository.</param>
        public RegisterVehicleUseCase(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        /// <summary>
        /// Executes the use case to register a new vehicle.
        /// </summary>
        /// <param name="input">The input data required to register the vehicle.</param>
        /// <param name="session">The client session handle for MongoDB transactions.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The output data containing the unique identifier of the registered vehicle.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input is null.</exception>
        public async Task<RegisterVehicleOutput> Execute(RegisterVehicleInput input, IClientSessionHandle session, CancellationToken cancellationToken)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var vehicle = new Domain.Vehicle.Vehicle()
            {
                Brand = input.Brand,
                Model = input.Model,
                Year = input.Year,
                LicensePlate = input.LicensePlate,
                IsAvailable = true
            };
            await _vehicleRepository.InsertOneAsync(vehicle, session, cancellationToken);
            return new RegisterVehicleOutput(vehicle.Id.ToString());
        }
    }
}
