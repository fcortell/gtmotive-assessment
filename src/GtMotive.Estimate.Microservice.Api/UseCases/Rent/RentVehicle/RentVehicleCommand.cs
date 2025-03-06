using System;
using FluentResults;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent.RentVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rent.RentVehicle
{
    public record RentVehicleCommand : IRequest<Result<RentVehicleOutput>>
    {
        public string VehicleId { get; init; }

        public string CustomerId { get; init; }

        public DateTime PlannedStartDate { get; init; }

        public DateTime PlannedEndDate { get; init; }

        public string Comments { get; init; }
    }
}
