namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rental.CheckoutVehicle
{
    public class CheckoutVehicleInput : IUseCaseInput
    {
        public string RentalId { get; set; }

        public string Comments { get; set; }
    }
}
