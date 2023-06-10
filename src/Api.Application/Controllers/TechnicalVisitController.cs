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

        [Authorize(Roles = "Agent")]
        [HttpGet]
        [Route("list-pending-visits")]
        public async Task<IActionResult> ListPendingVisits()
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            try
            {
                var visits = await _service.GetPendingVisits();

                return visits.Count() > 0 ? Ok(visits) : BadRequest("Não foram encontradas visitas pendentes.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Agent")]
        [HttpPut]
        [Route("finish-visit")]
        public async Task<IActionResult> FinishVisit([FromHeader] Guid visitId)
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            try
            {
                var finished = await _service.FinishVisit(visitId);

                return finished ? Ok() : BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
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
        [HttpGet]
        [Route("get-canceled-visits")]
        public async Task<IActionResult> GetCanceledVisits()
        {
            if (!ModelState.IsValid) return BadRequest(modelStateError + ModelState);

            try
            {
                var visits = await _service.SelectCanceledVisits();

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
        public async Task<IActionResult> CancelVisit([FromHeader] Guid visitId)
        {
            try
            {
                var canceled = await _service.CancelVisit(visitId);

                return canceled ? Ok() : BadRequest();
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
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
