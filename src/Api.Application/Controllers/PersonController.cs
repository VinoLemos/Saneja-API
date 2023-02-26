using System.Net;
using Api.Domain.Interfaces.Services.PersonServices;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        const string modelStateError = "Solicitação inválida: ";

        [HttpGet]
        [Route("get-clients")]
        public async Task<ActionResult> GetAll([FromServices] IPersonService service)
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            try
            {
                return Ok(await service.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("get-client")]
        public async Task<ActionResult> Get([FromServices] IPersonService service, [FromRoute] Guid personId)
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            try
            {
                return Ok(await service.Get(personId));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("client-exists")]
        public async Task<ActionResult> Exists([FromServices] IPersonService service, [FromRoute] Guid personId)
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            try
            {
                return Ok(await service.Exists(personId));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}