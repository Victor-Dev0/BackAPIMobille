using BackAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        [HttpGet("Receber")]
        public IActionResult Get()
        {
            var dados = new { Nome = "Victor", Email = "victor@victor.com", Senha = "1234" };
            return Ok(dados);
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar([FromBody] UsuarioDTO usuario)
        {
            return Ok(usuario);
        }
    }
}
