namespace Api.Models
{
    public class ClienteModel
    {
        public int ClienteId { get; set; }

        public string NomeCliente { get; set; } = string.Empty;

        public string FotoCliente { get; set; } = string.Empty;

        public string CpfCliente { get; set; } = string.Empty;

        public string TelefoneCliente { get; set; } = string.Empty;

        public string EmailCliente { get; set; } = string.Empty;

        public string SenhaCliente { get; set; } = string.Empty;

        public int PlanosId { get; set; }

        public static implicit operator List<object>(ClienteModel v)
        {
            throw new NotImplementedException();
        }
    }
}
