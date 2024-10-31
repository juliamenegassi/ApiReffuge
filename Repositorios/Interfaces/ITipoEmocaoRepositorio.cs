using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface ITipoEmocaoRepositorio
    {
        Task<List<TipoEmocaoModel>> GetAll();

        Task<TipoEmocaoModel> GetById(int id);

        Task<TipoEmocaoModel> InsertTipoEmocao(TipoEmocaoModel tipoEmocao);

        Task<TipoEmocaoModel> UpdateTipoEmocao(TipoEmocaoModel tipoEmocao, int id);

        Task<bool> DeleteTipoEmocao(int id);
    }
}
