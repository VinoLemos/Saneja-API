using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projeto_SaneJa.Dtos;
using Projeto_SaneJa.Models;
using Projeto_SaneJa.Repository;

namespace Projeto_SaneJa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImoveisController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public ImoveisController(IUnitOfWork context, IMapper mapper)
        {
            _uof = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ImovelDTO>> Get()
        {
            try
            {
                var imoveis = _uof.ImovelRepository?.Get().ToList();
                var imoveisDto = _mapper.Map<List<ImovelDTO>>(imoveis);
                return imoveisDto == null ?
                NotFound("Não foram encontrados imoveis") : imoveisDto;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao tratar sua solicitação");
            }
        }

        [HttpGet("{id:int}", Name = "ObterImovel")]
        public ActionResult<ImovelDTO> Get(int id)
        {
            try
            {
                var imovel = _uof.ImovelRepository?.GetById(c => c.ID == id);
                var imovelDto = _mapper.Map<ImovelDTO>(imovel);
                return imovelDto == null ? NotFound("Imovel não encontrado no sistema.") : imovelDto;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao tratar sua solicitação");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody]ImovelDTO imovelDto)
        {
            try
            {
                if (imovelDto is null) return BadRequest("Imovel inválido");

                var imovel = _mapper.Map<Imovel>(imovelDto);
                _uof.ImovelRepository.Add(imovel);
                _uof.Commit();

                imovelDto = _mapper.Map<ImovelDTO>(imovel);

                return Ok(imovelDto);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao tratar sua solicitação");
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody]ImovelDTO imovelDto)
        {
            try
            {
                if ( id != imovelDto.ID) return BadRequest();

                var imovel = _mapper.Map<Imovel>(imovelDto);

                _uof.ImovelRepository.Update(imovel);
                _uof.Commit();
                return Ok(imovelDto);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                $"Ocorreu um erro ao tratar sua solicitação: {ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<ImovelDTO> Delete(int id)
        {
            try
            {
                var imovel = _uof.ImovelRepository?.GetById(c => c.ID == id);
                if (imovel is null)
                {
                    return NotFound("Imovel não encontrado no sistema");
                }
                _uof.ImovelRepository?.Delete(imovel);
                _uof.Commit();

                var imovelDto = _mapper.Map<ImovelDTO>(imovel);

                return Ok(imovelDto);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                $"Ocorreu um erro ao tratar sua solicitação: {ex.Message}");
            }
        }
    }
}