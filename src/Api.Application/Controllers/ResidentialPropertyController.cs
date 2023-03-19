using Api.Domain.Interfaces.Services.ResidencialPropertyServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ResidentialPropertyController : ControllerBase
    {
        const string modelStateError = "Solicitação Inválida: ";

        private readonly IResidentialPropertyService _service;

        public ResidentialPropertyController(IResidentialPropertyService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("get-properties")]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            try
            {
                return Ok(await _service.GetAll());
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

        [HttpGet]
        [Route("get-property-by-street")]
        public async Task<IActionResult> GetByStreet(string? street)
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            if (String.IsNullOrEmpty(street)) return BadRequest("Rua inválida");

            try
            {
                var imovel = await _service.GetByStreet(street);
                return imovel != null ? Ok(imovel) : NotFound("Imóvel não encontrado");
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
