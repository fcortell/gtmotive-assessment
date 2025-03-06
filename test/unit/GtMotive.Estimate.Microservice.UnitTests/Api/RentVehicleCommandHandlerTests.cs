using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.Rent.RentVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent.RentVehicle;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MongoDB.Driver;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.Api
{
    public class RentVehicleCommandHandlerTests
    {
        private readonly Mock<IRentVehicleUseCase> _rentVehicleUseCaseMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly RentVehicleCommandHandler _handler;

        public RentVehicleCommandHandlerTests()
        {
            _rentVehicleUseCaseMock = new Mock<IRentVehicleUseCase>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _handler = new RentVehicleCommandHandler(_rentVehicleUseCaseMock.Object, _unitOfWorkMock.Object);
        }

        [Fact]
        public async Task HandleRequestIsNullReturnsFailResult()
        {
            // Arrange
            RentVehicleCommand request = null;
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
            var request = new RentVehicleCommand() { VehicleId = "vehicleId", CustomerId = "customerId", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), Comments = "comments" };
            var cancellationToken = CancellationToken.None;
            var sessionMock = new Mock<IClientSessionHandle>();
            var output = new RentVehicleOutput("rentalId");

            _unitOfWorkMock.Setup(u => u.BeginSessionAsync(cancellationToken)).ReturnsAsync(sessionMock.Object);
            _rentVehicleUseCaseMock.Setup(u => u.Execute(It.IsAny<RentVehicleInput>())).ReturnsAsync(output);

            // Act
            var result = await _handler.Handle(request, cancellationToken);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(output, result.Value);
            _unitOfWorkMock.Verify(u => u.DisposeSession(sessionMock.Object), Times.Once);
        }

        [Fact]
        public async Task HandleValidRequestReturnsFailResultWhenOutputIsNull()
        {
            // Arrange
            var request = new RentVehicleCommand()
            {
                VehicleId = "vehicleId",
                CustomerId = "customerId",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                Comments = "comments"
            };

            var cancellationToken = CancellationToken.None;
            var sessionMock = new Mock<IClientSessionHandle>();

            _unitOfWorkMock.Setup(u => u.BeginSessionAsync(cancellationToken)).ReturnsAsync(sessionMock.Object);
            _rentVehicleUseCaseMock.Setup(u => u.Execute(It.IsAny<RentVehicleInput>())).ReturnsAsync((RentVehicleOutput)null);

            // Act
            var result = await _handler.Handle(request, cancellationToken);

            // Assert
            Assert.True(result.IsFailed);
            _unitOfWorkMock.Verify(u => u.DisposeSession(sessionMock.Object), Times.Once);
        }
    }
}
