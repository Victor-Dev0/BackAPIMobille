using BackAPI.Model;
using BackAPI.Repositorio.Interfaces;
using BackAPI.Service.Interfaces;

namespace BackAPI.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepositorio _repositorio;

        public ClienteService(IClienteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Guid> CadastrarCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException("cliente veio vazio!");
            }
            return await _repositorio.CadastrarCliente(cliente);
        }

        public async Task<Cliente> Obter(Guid id)
        {
            return await _repositorio.Obter(id);
        }

        public async Task<List<Cliente>> ObterClientesPorUsuario(Guid usuarioId)
        {
            return await _repositorio.ObterClientesPorUsuario(usuarioId);
        }
    }
}
