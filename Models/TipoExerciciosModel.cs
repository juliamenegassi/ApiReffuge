namespace Api.Models
{
    public class TipoExerciciosModel
    {
        public int TipoExerciciosId { get; set; }

        public string NomeTipoExercicios { get; set; } = string.Empty;

        public static implicit operator List<object>(TipoExerciciosModel v)
        {
            throw new NotImplementedException();
        }
    }
}
