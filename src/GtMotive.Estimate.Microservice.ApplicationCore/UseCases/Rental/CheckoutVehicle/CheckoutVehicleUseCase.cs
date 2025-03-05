using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent.CheckoutVehicle;
using GtMotive.Estimate.Microservice.Domain;
using GtMotive.Estimate.Microservice.Domain.Rental;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rental.CheckoutVehicle
{
    public class CheckoutVehicleUseCase : ICheckoutVehicleUseCase
    {
        private readonly IRentalRepository _rentalRepository;

        public CheckoutVehicleUseCase(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

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
