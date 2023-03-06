using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonLoginController : ControllerBase
    {
        private readonly ILoginService<Person> _service;

        public PersonLoginController(ILoginService<Person> service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            if (login == null) return BadRequest("Usuário Inválido");

            try
            {
                var result = await _service.FindByLogin(login);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}