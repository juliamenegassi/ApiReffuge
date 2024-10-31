namespace Api.Models
{
    public class AgendamentoModel
    {
        public int AgendamentoId { get; set; }

        public int ClienteId { get; set; }

        public DateTime DataHora { get; set; }

        public int ProfissionalId { get; set; }

        public static implicit operator List<object>(AgendamentoModel v)
        {
            throw new NotImplementedException();
        }
    }
}
