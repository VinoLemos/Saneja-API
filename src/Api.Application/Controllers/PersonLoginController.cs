using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services;
using Api.Domain.Interfaces.Services.PersonServices;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonLoginController : ControllerBase
    {
        private ILoginService<Person> _service;

        public PersonLoginController(ILoginService<Person> service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<object> Login([FromBody] Person person)
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