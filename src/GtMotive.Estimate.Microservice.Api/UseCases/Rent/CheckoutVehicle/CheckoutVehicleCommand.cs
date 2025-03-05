using FluentResults;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent.CheckoutVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rent.CheckoutVehicle
{
    public class CheckoutVehicleCommand : IRequest<Result<CheckoutVehicleOutput>>
    {
        public string RentalId { get; set; }

        public string Comments { get; set; }
    }
}
