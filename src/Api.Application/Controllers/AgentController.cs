using Domain.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services.AgentServices;
using System.Net;
using System.Security.Claims;

namespace Application.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Agent")]
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        const string modelStateError = "Solicitação Inválida: ";

        private readonly AgentService _service;

        public AgentController(AgentService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("get-agents")]
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
        [Route("get-agent", Name = "GetWithId")]
        public async Task<IActionResult> Get([FromRoute] Guid agentId)
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            try
            {
                return Ok(await _service.SelectUserAsync(agentId));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("agent-exists")]
        public async Task<IActionResult> Exists([FromRoute] Guid agentId)
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            try
            {
                return Ok(await _service.UserExists(agentId));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Route("update-agent")]
        public IActionResult UpdateAgent([FromBody] UserUpdateDto user)
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
