using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projeto_SaneJa.Dtos;
using Projeto_SaneJa.Models;
using Projeto_SaneJa.Repository;

namespace Projeto_SaneJa.Controllers
{
    [Route("[controller]")]
    public class VisitaTecnicaController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public VisitaTecnicaController(IUnitOfWork context, IMapper mapper)
        {
            _uof = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VisitaTecnicaDTO>> Get()
        {
            try
            {
                var visitas = _uof.VisitaTecnicaRepository?.Get().ToList();
                var visitasDto = _mapper.Map<List<VisitaTecnicaDTO>>(visitas);
                return visitasDto == null ?
                NotFound("Não foram encontrados visitas") : visitasDto;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao tratar sua solicitação");
            }
        }

        [HttpGet("{id:int}", Name = "ObterVisita")]
        public ActionResult<VisitaTecnicaDTO> Get(int id)
        {
            try
            {
                var visita = _uof.VisitaTecnicaRepository?.GetById(v => v.ID == id);
                var visitaDto = _mapper.Map<VisitaTecnicaDTO>(visita);
                return visitaDto == null ? NotFound("Visita não encontrado no sistema.") : visitaDto;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao tratar sua solicitação");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody]VisitaTecnicaDTO visitaDto)
        {
            try
            {
                if (visitaDto is null) return BadRequest("Visita inválida");

                var visita = _mapper.Map<VisitaTecnica>(visitaDto);
                _uof.VisitaTecnicaRepository.Add(visita);
                _uof.Commit();

                visitaDto = _mapper.Map<VisitaTecnicaDTO>(visita);

                return Ok(visitaDto);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                $"Ocorreu um erro ao tratar sua solicitação: {ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody]VisitaTecnicaDTO visitaDto)
        {
            try
            {
                if (id != visitaDto.ID) return BadRequest();

                var visita = _mapper.Map<VisitaTecnica>(visitaDto);

                _uof.VisitaTecnicaRepository.Update(visita);
                _uof.Commit();
                return Ok(visitaDto);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao tratar sua solicitação");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<VisitaTecnicaDTO> Delete(int id)
        {
            try
            {
                var visita = _uof.VisitaTecnicaRepository?.GetById(v => v.ID == id);
                if (visita is null)
                {
                    return NotFound("Visita não encontrado no sistema");
                }
                _uof.VisitaTecnicaRepository?.Delete(visita);
                _uof.Commit();

                var visitaDto = _mapper.Map<VisitaTecnicaDTO>(visita);

                return Ok(visitaDto);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao tratar sua solicitação");
            }
        }
    }
}