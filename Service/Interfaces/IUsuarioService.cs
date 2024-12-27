﻿using BackAPI.Model;

namespace BackAPI.Service.Interfaces
{
    public interface IUsuarioService
    {
        public Task<Guid> CriarUsuario(Usuario usuario);
        public Task<List<Usuario>> ObterUsuarios();
        public Task<Usuario> LerUsuarioPorId(Guid id);
        public Task<Usuario> AtualizarUsuario(Guid id, Usuario usuario);
        public Task<Guid> DeletarUsuario(Guid id);

        public Task<Usuario> Login(string email, string senha);
    }
}