using BackAPI.Data;
using BackAPI.Model;
using BackAPI.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackAPI.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly UsuariosDb _db;

        public ClienteRepositorio(UsuariosDb db)
        {
            _db = db;
        }

        public async Task<Guid> CadastrarCliente(Cliente cliente)
        {
            var aux = await _db.Usuarios.Where(c => c.Id == cliente.UsuarioId).FirstOrDefaultAsync();

            if (aux == null)
            {
                throw new ArgumentNullException("Id do Usuario informado não encontrado!");
            }

            cliente.DataCriacao = DateTimeOffset.Now;
            cliente.DataAtualizacao = DateTimeOffset.Now;

            _db.Clientes.Add(cliente);
            await _db.SaveChangesAsync();

            return cliente.Id;
        }

        public async Task<Cliente> Obter(Guid id)
        {
            var cliente = await _db.Clientes.FindAsync(id);

            return cliente;
        }

        public async Task<List<Cliente>> ObterClientesPorUsuario(Guid usuarioId)
        {
            var clientes = await _db.Clientes.Where(c => c.UsuarioId == usuarioId).ToListAsync();

            return clientes;
        }
    }
}
