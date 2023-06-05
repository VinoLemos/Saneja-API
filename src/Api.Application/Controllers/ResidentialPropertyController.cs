using Api.Service.Services.ResidencialPropertyServices;
using Domain.Dtos.ResidentialPropertyDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace Application.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ResidentialPropertyController : ControllerBase
    {
        const string modelStateError = "Solicitação Inválida: ";

        private readonly ResidentialPropertyService _service;

        public ResidentialPropertyController(ResidentialPropertyService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Person")]
        [HttpGet]
        [Route("get-user-properties")]
        public async Task<IActionResult> GetUserProperties()
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            try
            {
                return Ok(await _service.GetUserProperties(ReadUserId()));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("get-property")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("get-property-by-rgi")]
        public async Task<IActionResult> GetByRgi([FromRoute] int? rgi)
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            if (rgi == null) return BadRequest("RGI inválido");

            try
            {
                var imovel = await _service.GetByRgi(rgi);
                return imovel != null ? Ok(imovel) : NotFound("Imóvel não encontrado");
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Person")]
        [HttpPost]
        [Route("register-property")]
        public async Task<IActionResult> RegisterProperty([FromBody] ResidentialPropertyDto obj)
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);
            try
            {
                var created = await _service.Post(obj, ReadUserId());

                if (!created) return BadRequest("Imóvel não registrado");

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Person")]
        [HttpPut]
        [Route("update-property")]
        public IActionResult UpdateProperty([FromBody] ResidentialPropertyDto obj)
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            try
            {
                var updated = _service.Put(obj);
                if (!updated) return BadRequest("Imóvel não atualizado");

                return Ok();
            }
            catch (Exception)
            {

                throw;
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
