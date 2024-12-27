using BackAPI.Model;
using BackAPI.Repositorio.Interfaces;
using BackAPI.Service.Interfaces;

namespace BackAPI.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepositorio _userRepositorio;

        public UsuarioService(IUsuarioRepositorio usuarioRepositorio)
        {
            _userRepositorio = usuarioRepositorio;
        }

        public async Task<Usuario> AtualizarUsuario(Guid id, Usuario usuario)
        {
            var att = await _userRepositorio.AtualizarUsuario(id, usuario);

            return att;
        }

        public async Task<Guid> CriarUsuario(Usuario usuario)
        {
            var res = await _userRepositorio.CriarUsuario(usuario);

            return res;
        }

        public async Task<Guid> DeletarUsuario(Guid id)
        {
            var res = await _userRepositorio.DeletarUsuario(id);

            return res;
        }

        public async Task<Usuario> LerUsuarioPorId(Guid id)
        {
            var res = await _userRepositorio.LerUsuarioPorId(id);

            return res;
        }

        public async Task<Usuario> Login(string email, string senha)
        {
            var res = await _userRepositorio.Login(email, senha);

            return res;
        }

        public async Task<List<Usuario>> ObterUsuarios()
        {
            var res = await _userRepositorio.ObterUsuarios();

            return res;
        }
    }
}
