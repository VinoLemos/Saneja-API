using Api.Domain.Interfaces.Services.PersonServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services.PersonServices;
using System.Net;

namespace Api.Application.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Person")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        const string modelStateError = "Solicitação inválida: ";

        private readonly PersonService _service;

        public PersonController(PersonService service)
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
                return Ok(await _service.ListUsersAsync());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("get-client")]
        public async Task<IActionResult> Get([FromHeader] Guid personId)
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            try
            {
                return Ok(await _service.SelectUserAsync(personId));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("client-exists")]
        public async Task<IActionResult> Exists([FromHeader] Guid personId)
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            try
            {
                return Ok(await _service.UserExists(personId));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}