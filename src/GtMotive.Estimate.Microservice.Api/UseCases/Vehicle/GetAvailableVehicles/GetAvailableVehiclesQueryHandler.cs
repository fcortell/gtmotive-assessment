using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle.GetAvailableVehicles;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.GetAvailableVehicles
{
    public class GetAvailableVehiclesQueryHandler : IRequestHandler<GetAvailableVehiclesQuery, Result<GetAvailableVehiclesOutput>>
    {
        private readonly IGetAvailableVehiclesUseCase _getAvailableVehicleUseCase;

        public GetAvailableVehiclesQueryHandler(IGetAvailableVehiclesUseCase getAvailableVehiclesUseCase)
        {
            _getAvailableVehicleUseCase = getAvailableVehiclesUseCase;
        }

        public async Task<Result<GetAvailableVehiclesOutput>> Handle(GetAvailableVehiclesQuery request, CancellationToken cancellationToken)
        {
            var output = await _getAvailableVehicleUseCase.Execute();

            return output is not null ? Result.Ok(output) : Result.Fail<GetAvailableVehiclesOutput>("An error ocurred.");
        }
    }
}
