using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projeto_SaneJa.Dtos;
using Projeto_SaneJa.Models;
using Projeto_SaneJa.Repository;

namespace Projeto_SaneJa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public ClientesController(IUnitOfWork context, IMapper mapper)
        {
            _uof = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClienteDTO>> Get()
        {
            try
            {
                var clientes = _uof.ClienteRepository?.Get().ToList();
                var clientesDto = _mapper.Map<List<ClienteDTO>>(clientes);
                return clientesDto == null ?
                NotFound("Não foram encontrados clientes") : clientesDto;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao tratar sua solicitação");
            }
        }

        [HttpGet("{id:int}", Name = "ObterCliente")]
        public ActionResult<ClienteDTO> Get(int id)
        {
            try
            {
                var cliente = _uof.ClienteRepository?.GetById(c => c.ID == id);
                var clienteDto = _mapper.Map<ClienteDTO>(cliente);
                return clienteDto == null ? NotFound("Cliente não encontrado no sistema.") : clienteDto;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao tratar sua solicitação");
            }
        }

        [HttpGet("[action]/{email}", Name = "ObterClientePorEmail")]
        public ActionResult<ClienteDTO> GetByEmail(string email)
        {
            try
            {
                var cliente = _uof.ClienteRepository?.GetByEmail(c => c.Login == email );
                var clienteDto = _mapper.Map<ClienteDTO>(cliente);
                return clienteDto == null ? NotFound("Cliente não encontrado no sistema.") : clienteDto;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao tratar sua solicitação");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody]ClienteDTO clienteDto)
        {
            try
            {
                if (clienteDto is null) return BadRequest("Cliente inválido");
                
                var cliente = _mapper.Map<Cliente>(clienteDto);
                _uof.ClienteRepository.Add(cliente);
                _uof.Commit();

                clienteDto = _mapper.Map<ClienteDTO>(cliente);

                return Ok(clienteDto);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody]ClienteDTO clienteDto)
        {
            try
            {
                if (id != clienteDto.ID) return BadRequest("CPF inválido");
                
                var cliente = _mapper.Map<Cliente>(clienteDto);

                if (cliente is null) return BadRequest("Cliente inválido");

                _uof.ClienteRepository.Update(cliente);
                _uof.Commit();
                return Ok(clienteDto);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                $"Ocorreu um erro ao tratar sua solicitação: {ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<ClienteDTO> Delete(int id)
        {
            try
            {
                var cliente = _uof.ClienteRepository?.GetById(c => c.ID == id);
                if (cliente is null)
                {
                    return NotFound("Cliente não encontrado no sistema");
                }
                _uof.ClienteRepository?.Delete(cliente);
                _uof.Commit();

                var clienteDto = _mapper.Map<ClienteDTO>(cliente);

                return Ok(clienteDto);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Ocorreu um erro ao tratar sua solicitação");
            }
        }
    }
}