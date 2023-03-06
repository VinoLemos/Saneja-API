﻿using Api.Domain.Interfaces.Services.AgentServices;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        const string modelStateError = "Solicitação Inválida: ";

        private readonly IAgentService _service;

        public AgentController(IAgentService service)
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
        [Route("get-agent")]
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
    }
}