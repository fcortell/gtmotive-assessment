using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent.RentVehicle;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rent.RentVehicle
{
    public class RentVehicleCommandHandler : IRequestHandler<RentVehicleCommand, Result<RentVehicleOutput>>
    {
        private readonly IRentVehicleUseCase _rentVehicleUseCase;
        private readonly IUnitOfWork _unitOfWork;

        public RentVehicleCommandHandler(IRentVehicleUseCase rentVehicleUseCase, IUnitOfWork unitOfWork)
        {
            _rentVehicleUseCase = rentVehicleUseCase;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<RentVehicleOutput>> Handle(RentVehicleCommand request, CancellationToken cancellationToken)
        {
            if (request is not null)
            {
                var input = new RentVehicleInput
                {
                    VehicleId = request.VehicleId,
                    CustomerId = request.CustomerId,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    Comments = request.Comments
                };

                var session = await _unitOfWork.BeginSessionAsync(cancellationToken);

                var output = await _rentVehicleUseCase.Execute(input);

                _unitOfWork.DisposeSession(session);

                if (output is not null)
                {
                    return Result.Ok(output);
                }
            }

            return Result.Fail<RentVehicleOutput>("Request is null");
        }
    }
}
