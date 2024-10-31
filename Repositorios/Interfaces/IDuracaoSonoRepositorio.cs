using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IDuracaoSonoRepositorio
    {
        Task<List<DuracaoSonoModel>> GetAll();

        Task<DuracaoSonoModel> GetById(int id);

        Task<DuracaoSonoModel> InsertDuracaoSono(DuracaoSonoModel duracaoSono);

        Task<DuracaoSonoModel> UpdateDuracaoSono(DuracaoSonoModel duracaoSono, int id);

        Task<bool> DeleteDuracaoSono(int id);
    }
}
