namespace Api.Models
{
    public class ExerciciosModel
    {
        public int ExerciciosId { get; set; }

        public string NomeExercicios { get; set; } = string.Empty;

        public int TipoExerciciosId { get; set; }

        public static implicit operator List<object>(ExerciciosModel v)
        {
            throw new NotImplementedException();
        }
    }
}
