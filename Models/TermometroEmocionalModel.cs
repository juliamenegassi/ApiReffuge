using System;

namespace Api.Models
{
    public class TermometroEmocionalModel
    {
        public int TermometroEmocionalId { get; set; }

        public int TipoEmocaoId { get; set; }

        public int ClienteId { get; set; }
        public DateTime Data { get; set; }

        public static implicit operator List<object>(TermometroEmocionalModel v)
        {
            throw new NotImplementedException();
        }
    }
}
