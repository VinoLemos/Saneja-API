using System.Net;
using Api.Domain.Interfaces.Services;
using Api.Domain.Interfaces.Services.PersonServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        const string modelStateError = "Solicitação inválida: ";

        private readonly IPersonService _service;

        public PersonController(IPersonService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("get-clients")]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("get-client")]
        public async Task<IActionResult> Get([FromRoute] Guid personId)
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            try
            {
                return Ok(await _service.Get(personId));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("client-exists")]
        public async Task<IActionResult> Exists([FromRoute] Guid personId)
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            try
            {
                return Ok(await _service.Exists(personId));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}