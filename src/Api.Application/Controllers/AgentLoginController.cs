using System.Net;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentLoginController : ControllerBase
    {
        private ILoginService<Agent> _service;

        public AgentLoginController(ILoginService<Agent> service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<object> Login([FromBody] Agent person)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            if (person == null) return BadRequest("Usuário Inválido");

            try
            {
                var result = await _service.FindByLogin(person);

                if (result == null) return NotFound();

                return result;
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}