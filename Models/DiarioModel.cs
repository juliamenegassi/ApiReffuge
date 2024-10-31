namespace Api.Models
{
    public class DiarioModel
    {
        public int DiarioId { get; set; }

        public DateTime DataHorario { get; set; }

        public string ConteudoDiario { get; set; } = string.Empty;

        public int ClienteId { get; set; }

        public static implicit operator List<object>(DiarioModel v)
        {
            throw new NotImplementedException();
        }
    }
}
