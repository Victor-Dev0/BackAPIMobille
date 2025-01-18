namespace BackAPI.DTO
{
    public class ClienteDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public Guid UsuarioId { get; set; }
    }
}
