using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle.RegisterVehicle;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.RegisterVehicle
{
    public class RegisterVehicleCommandHandler : IRequestHandler<RegisterVehicleCommand, Result<RegisterVehicleOutput>>
    {
        private readonly IRegisterVehicleUseCase _registerVehicleUseCase;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterVehicleCommandHandler(IRegisterVehicleUseCase registerVehicleUseCase, IUnitOfWork unitOfWork)
        {
            _registerVehicleUseCase = registerVehicleUseCase;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<RegisterVehicleOutput>> Handle(RegisterVehicleCommand request, CancellationToken cancellationToken)
        {
            if (request is not null)
            {
                var input = new RegisterVehicleInput
                {
                    Brand = request.Brand,
                    Model = request.Model,
                    Year = request.Year,
                    LicensePlate = request.LicensePlate,
                    Color = request.Color,
                    Description = request.Description
                };
                var session = await _unitOfWork.BeginSessionAsync(cancellationToken);
                var output = await _registerVehicleUseCase.Execute(input, session, cancellationToken);
                _unitOfWork.DisposeSession(session);
                if (output is not null)
                {
                    return Result.Ok(output);
                }
            }

            return Result.Fail<RegisterVehicleOutput>("Request is null");
        }
    }
}
