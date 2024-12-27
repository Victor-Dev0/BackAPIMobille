namespace BackAPI.Model.Base
{
    public class BaseModel
    {
        public BaseModel()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public DateTimeOffset DataCriacao { get; set; }
        public DateTimeOffset DataAtualizacao { get; set; }
    }
}
