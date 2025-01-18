using BackAPI.Model;

namespace BackAPI.Service.Interfaces
{
    public interface IClienteService
    {
        public Task<Guid> CadastrarCliente(Cliente cliente);
        public Task<Cliente> Obter(Guid id);
        public Task<List<Cliente>> ObterClientesPorUsuario(Guid usuarioId);
    }
}
