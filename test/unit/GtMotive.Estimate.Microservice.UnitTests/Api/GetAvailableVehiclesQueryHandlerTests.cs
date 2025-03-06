using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.GetAvailableVehicles;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle.GetAvailableVehicles;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.Api
{
    public class GetAvailableVehiclesQueryHandlerTests
    {
        private readonly Mock<IGetAvailableVehiclesUseCase> _mockGetAvailableVehiclesUseCase;
        private readonly GetAvailableVehiclesQueryHandler _handler;

        public GetAvailableVehiclesQueryHandlerTests()
        {
            _mockGetAvailableVehiclesUseCase = new Mock<IGetAvailableVehiclesUseCase>();
            _handler = new GetAvailableVehiclesQueryHandler(_mockGetAvailableVehiclesUseCase.Object);
        }

        [Fact]
        public async Task HandleShouldReturnOkResultWhenVehiclesAreAvailable()
        {
            // Arrange
            var vehicles = new List<Domain.Vehicle.Vehicle>
        {
            new() { Id = "1", Brand = "BrandA", Model = "ModelA", IsAvailable = true },
            new() { Id = "2", Brand = "BrandB", Model = "ModelB", IsAvailable = true }
        };
            var output = new GetAvailableVehiclesOutput(vehicles);
            _mockGetAvailableVehiclesUseCase.Setup(x => x.Execute()).ReturnsAsync(output);

            var query = new GetAvailableVehiclesQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(output, result.Value);
        }

        [Fact]
        public async Task HandleShouldReturnFailResultWhenNoVehiclesAreAvailable()
        {
            // Arrange
            _mockGetAvailableVehiclesUseCase.Setup(x => x.Execute()).ReturnsAsync((GetAvailableVehiclesOutput)null);

            var query = new GetAvailableVehiclesQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("An error ocurred.", result.Errors[0].Message);
        }
    }
}
