using AutoMapper;
using BackAPI.DTO;
using BackAPI.Model;
using BackAPI.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackAPI.Controllers
{
    [Route("cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;
        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [HttpGet("obter")]
        public async Task<ActionResult<ClienteDTO>> ObterCliente(Guid id)
        {
            try
            {
                var res = await _clienteService.Obter(id);

                if (res == null)
                {
                    return NotFound("Cliente não encontrado!");
                }

                return Ok(_mapper.Map<ClienteDTO>(res));
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
        }

        [HttpPost("inserir")]
        public async Task<ActionResult<Guid>> InserirCliente([FromBody] ClienteDTO cliente)
        {
            try
            {
                var res = await _clienteService.CadastrarCliente(_mapper.Map<Cliente>(cliente));

                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
        }

        [HttpGet("obterPorUsuario")]
        public async Task<ActionResult<List<ClienteDTO>>> ObterPorUsuario(Guid usuarioId)
        {
            try
            {
                var res = await _clienteService.ObterClientesPorUsuario(usuarioId);

                if (res == null)
                {
                    return NotFound("Nenhum cliente encontrado!");
                }

                return Ok(_mapper.Map<List<ClienteDTO>>(res));
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
        }
    }
}
