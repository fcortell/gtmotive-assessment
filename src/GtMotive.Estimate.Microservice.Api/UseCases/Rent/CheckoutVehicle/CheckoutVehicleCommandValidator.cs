using FluentValidation;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rent.CheckoutVehicle
{
    public class CheckoutVehicleCommandValidator : AbstractValidator<CheckoutVehicleCommand>
    {
        public CheckoutVehicleCommandValidator()
        {
            RuleFor(x => x.RentalId).NotEmpty();
        }
    }
}
