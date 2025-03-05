using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.RegisterVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicle.RegisterVehicle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [Route("api/[controller]")]
    public class VehicleController : BaseController
    {
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegisterVehicleOutput))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> RegisterVehicle([FromBody] RegisterVehicleCommand command)
        {
            var result = await Mediator.Send(command);

            return result.IsSuccess ? Ok(result.Value) : (IActionResult)Problem();
        }
    }
}
