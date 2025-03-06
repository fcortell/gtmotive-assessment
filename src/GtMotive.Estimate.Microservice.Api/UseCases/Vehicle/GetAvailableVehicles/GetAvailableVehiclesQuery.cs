using FluentResults;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle.GetAvailableVehicles;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.GetAvailableVehicles
{
    public class GetAvailableVehiclesQuery : IRequest<Result<GetAvailableVehiclesOutput>>
    {
    }
}
