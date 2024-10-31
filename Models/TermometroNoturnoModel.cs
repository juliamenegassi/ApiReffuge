using System;

namespace Api.Models
{
    public class TermometroNoturnoModel
    {
        public int TermometroNoturnoId { get; set; }

        public DateTime Data { get; set; }

        public int DuracaoSonoId { get; set; }

        public int VezesAcordou { get; set; }

        public int TipoSentimentoSonoId { get; set; }

        public int ClienteId { get; set; }

        public static implicit operator List<object>(TermometroNoturnoModel v)
        {
            throw new NotImplementedException();
        }

    }
}
