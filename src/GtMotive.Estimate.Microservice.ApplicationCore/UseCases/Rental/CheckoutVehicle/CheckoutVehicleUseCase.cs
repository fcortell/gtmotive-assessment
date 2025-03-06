using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent.CheckoutVehicle;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Rental;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rental.CheckoutVehicle
{
    /// <summary>
    /// Use case for checking out a vehicle rental.
    /// </summary>
    public class CheckoutVehicleUseCase : ICheckoutVehicleUseCase
    {
        private readonly IRentalRepository _rentalRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutVehicleUseCase"/> class.
        /// </summary>
        /// <param name="rentalRepository">The rental repository.</param>
        public CheckoutVehicleUseCase(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        /// <summary>
        /// Executes the checkout vehicle use case.
        /// </summary>
        /// <param name="input">The input data for the use case.</param>
        /// <param name="session">The client session handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The output data of the use case.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input is null.</exception>
        /// <exception cref="DomainException">Thrown when the rental is not found or already checked out.</exception>
        public async Task<CheckoutVehicleOutput> Execute(CheckoutVehicleInput input, IClientSessionHandle session, CancellationToken cancellationToken)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var rental = await _rentalRepository.FindByIdAsync(input.RentalId, cancellationToken) ?? throw new DomainException($"Rental {input.RentalId} not found.");

            if (rental.EndDate is not null)
            {
                throw new DomainException($"Rental {input.RentalId} already checked out.");
            }

            rental.EndDate = DateTime.UtcNow;

            await _rentalRepository.Update(rental);
            return new CheckoutVehicleOutput(rental.Id);
        }
    }
}
