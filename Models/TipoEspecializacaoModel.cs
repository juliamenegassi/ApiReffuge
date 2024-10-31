namespace Api.Models
{
    public class TipoEspecializacaoModel
    {
        public int TipoEspecializacaoId { get; set; }

        public string NomeTipoEspecializacao { get; set; } = string.Empty;

        public static implicit operator List<object>(TipoEspecializacaoModel v)
        {
            throw new NotImplementedException();
        }
    }
}
