using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projeto_SaneJa.Dtos;
using Projeto_SaneJa.Models;
using Projeto_SaneJa.Repository;

namespace Projeto_SaneJa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgentesController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public AgentesController(IUnitOfWork context, IMapper mapper)
        {
            _uof = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AgenteDTO>> Get()
        {
            try
            {
                var agentes = _uof.AgenteRepository?.Get().ToList();
                var agentesDto = _mapper.Map<List<AgenteDTO>>(agentes);
                return agentesDto == null ?
                NotFound("Não foram encontrados agentes") : agentesDto;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao tratar sua solicitação");
            }
        }

        [HttpGet("{id:int}", Name = "ObterAgente")]
        public ActionResult<AgenteDTO> Get(int id)
        {
            try
            {
                var agente = _uof.AgenteRepository?.GetById(c => c.ID == id);
                var agenteDto = _mapper.Map<AgenteDTO>(agente);
                return agenteDto == null ? NotFound("Agente não encontrado no sistema.") : agenteDto;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao tratar sua solicitação");
            }
        }

        [HttpGet("[action]/{email}", Name = "ObterAgentePorEmail")]
        public ActionResult<AgenteDTO> GetByEmail(string email)
        {
            try
            {
                var agente = _uof.AgenteRepository?.GetByEmail(a => a.Login == email );
                var agenteDto = _mapper.Map<AgenteDTO>(agente);
                return agenteDto == null ? NotFound("Agente não encontrado no sistema.") : agenteDto;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao tratar sua solicitação");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody]AgenteDTO agenteDto)
        {
            try
            {
                var agente = _mapper.Map<AgenteDeSaneamento>(agenteDto);
                _uof.AgenteRepository.Add(agente);
                _uof.Commit();

                agenteDto = _mapper.Map<AgenteDTO>(agente);

                return Ok(agenteDto);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao tratar sua solicitação");
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody]AgenteDTO agenteDto)
        {
            try
            {
                if (id != agenteDto.ID) return BadRequest();

                var agente = _mapper.Map<AgenteDeSaneamento>(agenteDto);

                _uof.AgenteRepository.Update(agente);
                _uof.Commit();
                return Ok(agenteDto);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                $"Ocorreu um erro ao tratar sua solicitação: {ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<AgenteDTO> Delete(int id)
        {
            try
            {
                var agente = _uof.AgenteRepository?.GetById(c => c.ID == id);
                if (agente is null)
                {
                    return NotFound("Agente não encontrado no sistema");
                }
                _uof.AgenteRepository?.Delete(agente);
                _uof.Commit();

                var agenteDto = _mapper.Map<AgenteDTO>(agente);

                return Ok(agenteDto);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao tratar sua solicitação");
            }
        }
    }
}