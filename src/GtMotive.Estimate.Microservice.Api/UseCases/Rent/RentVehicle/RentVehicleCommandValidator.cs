using FluentValidation;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rent.RentVehicle
{
    public class RentVehicleCommandValidator : AbstractValidator<RentVehicleCommand>
    {
        public RentVehicleCommandValidator()
        {
            RuleFor(x => x.VehicleId).NotEmpty();
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty();
        }
    }
}
