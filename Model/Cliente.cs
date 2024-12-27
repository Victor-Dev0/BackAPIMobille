using BackAPI.Model.Base;

namespace BackAPI.Model
{
    public class Cliente : BaseModel
    {
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;

        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
