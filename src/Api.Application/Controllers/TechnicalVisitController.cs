using Api.Service.Services.TechnicalVisitServices;
using Domain.Dtos.TechnicalVisitDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

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

        [Authorize(Roles = "Person")]
        [HttpPost]
        [Route("request-visit")]
        public async Task<IActionResult> RequestVisit(TechnicalVisitCreateDto visit)
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            try
            {
                var visitCreated = await _service.Post(visit);

                return visitCreated ? Ok() : BadRequest("Visita não cadastrada.");
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
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
        public async Task<IActionResult> GetAgentVisits()
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            try
            {
                var visits = await _service.GetAgentVisits(ReadUserId());

                if (visits == null) return NoContent();

                return Ok(visits);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize(Roles = "Person")]
        [HttpGet]
        [Route("get-person-visits")]
        public async Task<IActionResult> GetPersonVisits()
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            try
            {
                var visits = await _service.GetPersonVisits(ReadUserId());

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
        [Route("accept-visit")]
        public IActionResult AcceptVisit([FromHeader] Guid visitId)
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            try
            {
                var accepted = _service.AcceptVisit(visitId, ReadUserId());

                if (accepted == false) return BadRequest();

                return Ok();
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
