using BackAPI.Data;
using BackAPI.Model;
using BackAPI.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackAPI.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly UsuariosDb Db;

        public UsuarioRepositorio(UsuariosDb contexto)
        {
            Db = contexto;
        }
        public async Task<Guid> CriarUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new Exception("Usuario veio nulo");
            }

            usuario.DataCriacao = DateTimeOffset.Now;
            usuario.DataAtualizacao = DateTimeOffset.Now;

            Db.Usuarios.Add(usuario);
            await Db.SaveChangesAsync();

            return usuario.Id;
        }

        public async Task<Usuario> AtualizarUsuario(Guid id, Usuario usuario)
        {
            var usuarioAtualizar = await Db.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

            if (usuarioAtualizar == null)
            {
                throw new Exception("Usuario nao encontrado");
            }

            usuarioAtualizar.Nome = usuario.Nome;
            usuarioAtualizar.Senha = usuario.Senha;
            usuarioAtualizar.Email = usuario.Email;
            usuarioAtualizar.DataAtualizacao = DateTimeOffset.Now;

            Db.Usuarios.Update(usuarioAtualizar);
            await Db.SaveChangesAsync();

            return usuarioAtualizar;
        }

        public async Task<Guid> DeletarUsuario(Guid id)
        {
            var usuario = await Db.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

            if (usuario == null)
            {
                throw new Exception("Usuario nao encontrado");
            }

            Db.Usuarios.Remove(usuario);
            await Db.SaveChangesAsync();

            return usuario.Id;
        }

        public async Task<Usuario> LerUsuarioPorId(Guid id)
        {
            var usuario = await Db.Usuarios.FirstOrDefaultAsync(x => x.Id == id);

            if (usuario == null)
            {
                throw new Exception("Usuario nao encontrado");
            }

            return usuario;
        }

        public async Task<List<Usuario>> ObterUsuarios()
        {
            var res = await Db.Usuarios.ToListAsync();

            return res;
        }

        public async Task<Usuario> Login(string email, string senha)
        {
            var user = await Db.Usuarios.Where(u => u.Email.Equals(email)).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new Exception("Email invalido");
            }

            if (user.Senha != senha)
            {
                throw new Exception("Senha invalida");
            }

            return user;
        }
    }
}
