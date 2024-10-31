namespace Api.Models
{
    public class DuracaoSonoModel
    {
        public int DuracaoSonoId { get; set; }

        public string NomeDuracaoSono { get; set; } = string.Empty;

        public static implicit operator List<object>(DuracaoSonoModel v)
        {
            throw new NotImplementedException();
        }
    }
}
