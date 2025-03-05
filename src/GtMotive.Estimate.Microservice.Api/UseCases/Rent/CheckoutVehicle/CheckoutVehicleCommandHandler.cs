using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent.CheckoutVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rental.CheckoutVehicle;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rent.CheckoutVehicle
{
    public class CheckoutVehicleCommandHandler : IRequestHandler<CheckoutVehicleCommand, Result<CheckoutVehicleOutput>>
    {
        private readonly ICheckoutVehicleUseCase _checkoutVehicleUseCase;
        private readonly IUnitOfWork _unitOfWork;

        public CheckoutVehicleCommandHandler(ICheckoutVehicleUseCase checkoutVehicleUseCase, IUnitOfWork unitOfWork)
        {
            _checkoutVehicleUseCase = checkoutVehicleUseCase;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<CheckoutVehicleOutput>> Handle(CheckoutVehicleCommand request, CancellationToken cancellationToken)
        {
            if (request is not null)
            {
                var input = new CheckoutVehicleInput
                {
                    RentalId = request.RentalId,
                    Comments = request.Comments
                };
                var session = await _unitOfWork.BeginSessionAsync(cancellationToken);
                var output = await _checkoutVehicleUseCase.Execute(input, session, cancellationToken);
                _unitOfWork.DisposeSession(session);
                if (output is not null)
                {
                    return Result.Ok(output);
                }
            }

            return Result.Fail<CheckoutVehicleOutput>("Request is null");
        }
    }
}
