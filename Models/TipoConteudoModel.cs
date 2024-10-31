namespace Api.Models
{
    public class TipoConteudoModel
    {
        public int TipoConteudoId { get; set; }
        public string NomeTipoConteudo { get; set; } = string.Empty;

        public static implicit operator List<object>(TipoConteudoModel v)
        {
            throw new NotImplementedException();
        }
    }
}
