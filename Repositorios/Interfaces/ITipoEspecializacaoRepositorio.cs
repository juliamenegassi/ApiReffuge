using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface ITipoEspecializacaoRepositorio
    {
        Task<List<TipoEspecializacaoModel>> GetAll();

        Task<TipoEspecializacaoModel> GetById(int id);

        Task<TipoEspecializacaoModel> InsertTipoEspecializacao(TipoEspecializacaoModel tipoEspecializacao);

        Task<TipoEspecializacaoModel> UpdateTipoEspecializacao(TipoEspecializacaoModel tipoEspecializacao, int id);

        Task<bool> DeleteTipoEspecializacao(int id);
    }
}
