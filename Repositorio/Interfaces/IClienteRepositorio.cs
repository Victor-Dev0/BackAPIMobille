using BackAPI.Model;

namespace BackAPI.Repositorio.Interfaces
{
    public interface IClienteRepositorio
    {
        public Task<Guid> CadastrarCliente(Cliente cliente);
        public Task<Cliente> Obter(Guid id);
        public Task<List<Cliente>> ObterClientesPorUsuario(Guid usuarioId);
    }
}
