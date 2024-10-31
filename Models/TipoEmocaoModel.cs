namespace Api.Models
{
    public class TipoEmocaoModel
    {
        public int TipoEmocaoId { get; set; }

        public string NomeTipoEmocao { get; set; } = string.Empty;

        public static implicit operator List<object>(TipoEmocaoModel v)
        {
            throw new NotImplementedException();
        }
    }
}
