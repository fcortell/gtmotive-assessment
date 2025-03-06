using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.Rent.CheckoutVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent.CheckoutVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rental.CheckoutVehicle;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MongoDB.Driver;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.Api
{
    public class CheckoutVehicleCommandHandlerTests
    {
        private readonly Mock<ICheckoutVehicleUseCase> _mockCheckoutVehicleUseCase;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly CheckoutVehicleCommandHandler _handler;

        public CheckoutVehicleCommandHandlerTests()
        {
            _mockCheckoutVehicleUseCase = new Mock<ICheckoutVehicleUseCase>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _handler = new CheckoutVehicleCommandHandler(_mockCheckoutVehicleUseCase.Object, _mockUnitOfWork.Object);
        }

        [Fact]
        public async Task HandleRequestIsNullReturnsFailResult()
        {
            // Arrange
            CheckoutVehicleCommand request = null;
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
            var request = new CheckoutVehicleCommand
            {
                RentalId = "123",
                Comments = "Test comments"
            };
            var cancellationToken = CancellationToken.None;
            var sessionMock = new Mock<IClientSessionHandle>();
            var output = new CheckoutVehicleOutput(request.RentalId);

            _mockUnitOfWork.Setup(uow => uow.BeginSessionAsync(cancellationToken)).ReturnsAsync(sessionMock.Object);
            _mockCheckoutVehicleUseCase.Setup(uc => uc.Execute(It.IsAny<CheckoutVehicleInput>(), sessionMock.Object, cancellationToken)).ReturnsAsync(output);

            // Act
            var result = await _handler.Handle(request, cancellationToken);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(request.RentalId, result.Value.RentalId);
            _mockUnitOfWork.Verify(uow => uow.DisposeSession(sessionMock.Object), Times.Once);
        }
    }
}
