using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.Rent.CheckoutVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.Rent.RentVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent.CheckoutVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rent.RentVehicle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [Route("api/[controller]")]
    public class RentalController : BaseController
    {
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RentVehicleOutput))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> RentVehicle([FromBody] RentVehicleCommand command)
        {
            var result = await Mediator.Send(command);

            return result.IsSuccess ? Ok(result.Value) : (IActionResult)Problem();
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CheckoutVehicleOutput))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CheckoutVehicle([FromBody] CheckoutVehicleCommand command)
        {
            var result = await Mediator.Send(command);

            return result.IsSuccess ? Ok(result.Value) : (IActionResult)Problem();
        }
    }
}
