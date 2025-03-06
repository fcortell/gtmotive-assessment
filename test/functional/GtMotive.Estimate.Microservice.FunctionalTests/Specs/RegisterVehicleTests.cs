using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.RegisterVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle.RegisterVehicle;
using GtMotive.Estimate.Microservice.Domain.Vehicle;
using GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Specs
{
    public class RegisterVehicleTests : FunctionalTestBase
    {
        public RegisterVehicleTests(CompositionRootTestFixture fixture)
            : base(fixture)
        {
        }

        [Fact]
        public async Task RegisterVehicleInputShouldRegisterVehicleSuccessfully()
        {
            var vehicleId = string.Empty;

            // Arrange
            var command = new RegisterVehicleCommand()
            {
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2020
            };

            // Act
            await Fixture.UsingHandlerForRequestResponse<RegisterVehicleCommand, Result<RegisterVehicleOutput>>(async handler =>
            {
                var result = await handler.Handle(command, default);
                vehicleId = result.Value.VehicleId;
            });

            // Assert
            await Fixture.UsingRepository<IVehicleRepository>(async repository =>
            {
                var vehicle = await repository.FindByIdAsync(vehicleId, CancellationToken.None);
                Assert.NotNull(vehicle);
                Assert.Equal(command.Brand, vehicle.Brand);
                Assert.Equal(command.Model, vehicle.Model);
                Assert.Equal(command.Year, vehicle.Year);
            });
        }
    }
}
