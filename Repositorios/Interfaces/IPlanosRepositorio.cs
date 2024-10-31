using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IPlanosRepositorio
    {
        Task<List<PlanosModel>> GetAll();

        Task<PlanosModel> GetById(int id);

        Task<PlanosModel> InsertPlanos(PlanosModel planos);

        Task<PlanosModel> UpdatePlanos(PlanosModel planos, int id);

        Task<bool> DeletePlanos(int id);
    }
}
