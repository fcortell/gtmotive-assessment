using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Rental;
using GtMotive.Estimate.Microservice.Domain.Vehicle;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent.RentVehicle
{
    /// <summary>
    /// Use case for renting a vehicle.
    /// </summary>
    public class RentVehicleUseCase : IRentVehicleUseCase
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IVehicleRepository _vehicleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleUseCase"/> class.
        /// </summary>
        /// <param name="rentalRepository">The rental repository.</param>
        /// <param name="vehicleRepository">The vehicle repository.</param>
        public RentVehicleUseCase(IRentalRepository rentalRepository, IVehicleRepository vehicleRepository)
        {
            _rentalRepository = rentalRepository;
            _vehicleRepository = vehicleRepository;
        }

        /// <summary>
        /// Executes the use case to rent a vehicle.
        /// </summary>
        /// <param name="input">The input data for renting a vehicle.</param>
        /// <returns>The output data after renting a vehicle.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input is null.</exception>
        /// <exception cref="DomainException">Thrown when the customer already has an active rental or the vehicle is not available.</exception>
        public async Task<RentVehicleOutput> Execute(RentVehicleInput input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var activeRental = await _rentalRepository.GetActiveRentalByCustomer(input.CustomerId);
            var carRentalCollision = await _rentalRepository.GetScheduledRentalsByVehicle(input.VehicleId, input.StartDate, input.EndDate);

            if (activeRental != null)
            {
                throw new DomainException("Active rental for requested customer.");
            }

            var vehicleRequested = await _vehicleRepository.FindByIdAsync(input.VehicleId, CancellationToken.None);

            if ((vehicleRequested != null && !vehicleRequested.IsAvailable) || carRentalCollision.Count > 0)
            {
                throw new DomainException($"Vehicle {input.VehicleId} not available to rent.");
            }

            var rental = new Domain.Rental.Rental()
            {
                Comment = input.Comments,
                CustomerId = input.CustomerId,
                StartDate = input.StartDate,
                EndDate = input.EndDate,
                VehicleId = input.VehicleId,
                ModifiedAt = DateTime.Now
            };

            await _rentalRepository.AddAsync(rental);

            var output = new RentVehicleOutput(rental.Id.ToString());

            return output;
        }
    }
}
