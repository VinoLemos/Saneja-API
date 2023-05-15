using Api.Domain.Interfaces.Services.PersonServices;
using Domain.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Agent")]
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        const string modelStateError = "Solicitação Inválida: ";

        private readonly IUserService _service;

        public AgentController(IUserService service)
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
                return Ok(await _service.GetAll());
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
                return Ok(await _service.Get(agentId));
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
                return Ok(await _service.Exists(agentId));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [Route("create-agent")]
        public async Task<IActionResult> CreateAgent([FromBody] UserCreateDto agent)
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            try
            {
                var result = await _service.Post(agent);

                return result != null ? Created(new Uri(Url.Link("GetWithId", new { id = result.Id })), result) : BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Route("update-agent")]
        public async Task<IActionResult> UpdateAgent([FromBody] UserUpdateDto agent)
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            try
            {
                var result = await _service.Put(agent);

                return result != null ? Ok(result) : BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
