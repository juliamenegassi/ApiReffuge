using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface ITipoSentimentoSonoRepositorio
    {
        Task<List<TipoSentimentoSonoModel>> GetAll();

        Task<TipoSentimentoSonoModel> GetById(int id);

        Task<TipoSentimentoSonoModel> InsertTipoSentimentoSono(TipoSentimentoSonoModel tipoSentimentoSono);

        Task<TipoSentimentoSonoModel> UpdateTipoSentimentoSono(TipoSentimentoSonoModel tipoSentimentoSono, int id);

        Task<bool> DeleteTipoSentimentoSono(int id);
    }
}
