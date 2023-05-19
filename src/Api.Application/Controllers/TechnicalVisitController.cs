using Api.Service.Services.TechnicalVisitServices;
using Domain.Dtos.TechnicalVisitDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicalVisitController : ControllerBase
    {
        private const string modelStateError = "Solicitação Ínválida: ";

        private readonly TechnicalVisitService _service;

        public TechnicalVisitController(TechnicalVisitService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("get-visit")]
        public async Task<IActionResult> GetVisit(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            try
            {
                var visit = await _service.Get(id);

                if (visit == null) return NoContent();

                return Ok(visit);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize(Roles = "Agent")]
        [HttpGet]
        [Route("get-agent-visits")]
        public async Task<IActionResult> GetAgentVisits([FromHeader] Guid agentId)
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            try
            {
                var visits = await _service.GetAgentVisits(agentId);

                if (visits == null) return NoContent();

                return Ok(visits);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize(Roles = "Agent")]
        [HttpPut]
        [Route("visit-homologation")]
        public IActionResult HomologateVisit([FromBody] TechnicalVisitObservationDto homologation)
        {
            try
            {
                var homologated = _service.PostVisitObservation(homologation);

                return homologated ? Ok() : BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Route("cancel-visit")]
        public async Task<IActionResult> CancelVisit([FromHeader] Guid id)
        {
            try
            {
                var canceled = await _service.CancelVisit(id);

                return canceled ? Ok() : BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
