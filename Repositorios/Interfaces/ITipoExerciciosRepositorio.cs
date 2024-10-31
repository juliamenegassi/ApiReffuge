using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface ITipoExerciciosRepositorio
    {
        Task<List<TipoExerciciosModel>> GetAll();

        Task<TipoExerciciosModel> GetById(int id);

        Task<TipoExerciciosModel> InsertTipoExercicios(TipoExerciciosModel tipoExercicios);

        Task<TipoExerciciosModel> UpdateTipoExercicios(TipoExerciciosModel tipoExercicios, int id);

        Task<bool> DeleteTipoExercicios(int id);
    }
}
