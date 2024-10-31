using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface ITipoConteudoRepositorio
    {
        Task<List<TipoConteudoModel>> GetAll();

        Task<TipoConteudoModel> GetById(int id);

        Task<TipoConteudoModel> InsertTipoConteudo(TipoConteudoModel tipoConteudo);

        Task<TipoConteudoModel> UpdateTipoConteudo(TipoConteudoModel tipoConteudo, int id);

        Task<bool> DeleteTipoConteudo(int id);
    }
}
