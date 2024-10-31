namespace Api.Models
{
    public class ProfissionalModel
    {
        public int ProfissionalId { get; set; }

        public string FotoProfissional { get; set; } = string.Empty;

        public string NomeProfissional { get; set; } = string.Empty;

        public int TipoEspecializacaoId { get; set; }

        public string DescricaoProfissional { get; set; } = string.Empty;

        public static implicit operator List<object>(ProfissionalModel v)
        {
            throw new NotImplementedException();
        }
    }
}
