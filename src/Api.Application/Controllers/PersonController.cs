using Domain.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services.PersonServices;
using System.Net;
using System.Security.Claims;

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
        [Route("get-client-details")]
        public async Task<IActionResult> GetDetails()
        {
            try
            {
                return Ok(await _service.ReadUserDetails(ReadUserId()));
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

        [HttpPut]
        [Route("update-client")]
        public IActionResult UpdateClient([FromBody] UserUpdateDto user)
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            try
            {
                var updated = _service.UpdateUser(user);

                return updated ? Ok("Cliente atualizado") : BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        private Guid ReadUserId()
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!Guid.TryParse(userIdString, out var userId))
            {
                throw new ArgumentException("Invalid User ID format");
            }

            return userId;
        }
    }
}