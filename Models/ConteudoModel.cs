namespace Api.Models
{
    public class ConteudoModel
    {
        public int ConteudoId { get; set; }

        public string NomeConteudo { get; set; } = string.Empty;

        public int TipoConteudoId { get; set; }

        public static implicit operator List<object>(ConteudoModel v)
        {
            throw new NotImplementedException();
        }
    }
}
