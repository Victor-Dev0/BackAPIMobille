using AutoMapper;
using BackAPI.DTO;
using BackAPI.Model;
using BackAPI.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackAPI.Controllers
{
    [Route("usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("obter")]
        public async Task<ActionResult<UsuarioDTO>> ObterUsuario(Guid id)
        {
            var res = await _service.LerUsuarioPorId(id);

            if (res == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<UsuarioDTO>(res));
        }

        [HttpPost("inserir")]
        public async Task<ActionResult<Guid>> InserirUsuario([FromBody] UsuarioDTO usuario)
        {
            var res = await _service.CriarUsuario(_mapper.Map<Usuario>(usuario));

            return Ok(res);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioDTO>> Logar([FromBody] LoginDTO login)
        {
            var res = await _service.Login(login.Email, login.Senha);

            if (res == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<UsuarioDTO>(res));
        }
    }
}
