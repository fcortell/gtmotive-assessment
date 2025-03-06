using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.RegisterVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle.RegisterVehicle;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MongoDB.Driver;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.Api
{
    public class RegisterVehicleCommandHandlerTests
    {
        private readonly Mock<IRegisterVehicleUseCase> _mockRegisterVehicleUseCase;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly RegisterVehicleCommandHandler _handler;

        public RegisterVehicleCommandHandlerTests()
        {
            _mockRegisterVehicleUseCase = new Mock<IRegisterVehicleUseCase>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _handler = new RegisterVehicleCommandHandler(_mockRegisterVehicleUseCase.Object, _mockUnitOfWork.Object);
        }

        [Fact]
        public async Task HandleRequestIsNullReturnsFailResult()
        {
            // Arrange
            RegisterVehicleCommand request = null;
            var cancellationToken = CancellationToken.None;

            // Act
            var result = await _handler.Handle(request, cancellationToken);

            // Assert
            Assert.True(result.IsFailed);
            Assert.Equal("Request is null", result.Errors[0].Message);
        }

        [Fact]
        public async Task HandleValidRequestReturnsOkResult()
        {
            // Arrange
            var request = new RegisterVehicleCommand
            {
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2020,
                LicensePlate = "ABC123",
                Color = "Red",
                Description = "A nice car",
                PricePerDay = 50,
                IsAvailable = true,
                IsDeleted = false
            };
            var cancellationToken = CancellationToken.None;
            var session = Mock.Of<IClientSessionHandle>();
            var output = new RegisterVehicleOutput("vehicleId");

            _mockUnitOfWork.Setup(uow => uow.BeginSessionAsync(cancellationToken)).ReturnsAsync(session);
            _mockRegisterVehicleUseCase.Setup(uc => uc.Execute(It.IsAny<RegisterVehicleInput>(), session, cancellationToken)).ReturnsAsync(output);

            // Act
            var result = await _handler.Handle(request, cancellationToken);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(output, result.Value);
            _mockUnitOfWork.Verify(uow => uow.DisposeSession(session), Times.Once);
        }

        [Fact]
        public async Task HandleValidRequestReturnsFailResultWhenOutputIsNull()
        {
            // Arrange
            var request = new RegisterVehicleCommand
            {
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2020,
                LicensePlate = "ABC123",
                Color = "Red",
                Description = "A nice car",
                PricePerDay = 50,
                IsAvailable = true,
                IsDeleted = false
            };
            var cancellationToken = CancellationToken.None;
            var session = Mock.Of<IClientSessionHandle>();

            _mockUnitOfWork.Setup(uow => uow.BeginSessionAsync(cancellationToken)).ReturnsAsync(session);
            _mockRegisterVehicleUseCase.Setup(uc => uc.Execute(It.IsAny<RegisterVehicleInput>(), session, cancellationToken)).ReturnsAsync((RegisterVehicleOutput)null);

            // Act
            var result = await _handler.Handle(request, cancellationToken);

            // Assert
            Assert.True(result.IsFailed);
            _mockUnitOfWork.Verify(uow => uow.DisposeSession(session), Times.Once);
        }
    }
}
