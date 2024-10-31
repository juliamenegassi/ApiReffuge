namespace Api.Models
{
    public class TipoSentimentoSonoModel
    {
        public int TipoSentimentoSonoId { get; set; }

        public string NomeTipoSentimentoSono { get; set; } = string.Empty;


        public static implicit operator List<object>(TipoSentimentoSonoModel v)
        {
            throw new NotImplementedException();
        }
    }
}
