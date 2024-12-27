using BackAPI.Model.Base;

namespace BackAPI.Model
{
    public class Usuario : BaseModel
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;

        public List<Cliente>? Clientes { get; set; }
    }
}
