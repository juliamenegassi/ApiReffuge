using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IExerciciosRepositorio
    {
        Task<List<ExerciciosModel>> GetAll();

        Task<ExerciciosModel> GetById(int id);

        Task<ExerciciosModel> InsertExercicios(ExerciciosModel exercicios);

        Task<ExerciciosModel> UpdateExercicios(ExerciciosModel exercicios, int id);

        Task<bool> DeleteExercicios(int id);
    }
}
