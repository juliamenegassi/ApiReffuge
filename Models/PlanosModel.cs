namespace Api.Models
{
    public class PlanosModel
    {
        public int PlanosId { get; set; }

        public string NomePlanos { get; set; } = string.Empty;

        public double PrecoPlanos { get; set; }

        public string DescricaoPlanos { get; set; } = string.Empty;

        public string DuracaoPlanos { get; set; } = string.Empty;

        public static implicit operator List<object>(PlanosModel v)
        {
            throw new NotImplementedException();
        }
    }
}
