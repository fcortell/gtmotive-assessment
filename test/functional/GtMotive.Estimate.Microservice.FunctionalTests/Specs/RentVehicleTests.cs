using System;
using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using GtMotive.Estimate.Microservice.Api.UseCases.Rent.CheckoutVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.Rent.RentVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent.CheckoutVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent.RentVehicle;
using GtMotive.Estimate.Microservice.Domain.Vehicle;
using GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Specs
{
    public class RentVehicleTests : FunctionalTestBase
    {
        public RentVehicleTests(CompositionRootTestFixture fixture)
            : base(fixture)
        {
        }

        [Fact]
        public async Task RentVehicleInputShouldRentVehicleSuccessfully()
        {
            var vehicleId = "67c5ff33fc13ae1a4f527a5a"; // Assume this vehicle ID exists in the system
            var rentalId = string.Empty;

            // Arrange
            var rentCommand = new RentVehicleCommand()
            {
                VehicleId = vehicleId,
                CustomerId = "John Doe",
                PlannedStartDate = DateTime.Now,
                PlannedEndDate = DateTime.Now.AddDays(7)
            };

            // Act
            await Fixture.UsingHandlerForRequestResponse<RentVehicleCommand, Result<RentVehicleOutput>>(async handler =>
            {
                var result = await handler.Handle(rentCommand, default);
                rentalId = result.Value.RentalId;
            });

            // Assert
            await Fixture.UsingRepository<IVehicleRepository>(async repository =>
            {
                var vehicle = await repository.FindByIdAsync(vehicleId, CancellationToken.None);
                Assert.NotNull(vehicle);
                Assert.Equal(rentCommand.VehicleId, vehicle.Id);
            });

            // Cleanup
            var returnCommand = new CheckoutVehicleCommand()
            {
                RentalId = rentalId,
            };

            await Fixture.UsingHandlerForRequestResponse<CheckoutVehicleCommand, Result<CheckoutVehicleOutput>>(async handler =>
            {
                await handler.Handle(returnCommand, default);
            });
        }
    }
}
