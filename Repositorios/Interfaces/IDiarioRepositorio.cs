using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IDiarioRepositorio
    {
        Task<List<DiarioModel>> GetAll();

        Task<DiarioModel> GetById(int id);

        Task<DiarioModel> InsertDiario(DiarioModel diario);

        Task<DiarioModel> UpdateDiario(DiarioModel diario, int id);

        Task<bool> DeleteDiario(int id);
    }
}
