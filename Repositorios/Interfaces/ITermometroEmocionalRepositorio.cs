using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface ITermometroEmocionalRepositorio
    {
        Task<List<TermometroEmocionalModel>> GetAll();

        Task<TermometroEmocionalModel> GetById(int id);

        Task<TermometroEmocionalModel> InsertTermometroEmocional(TermometroEmocionalModel termometroEmocional);

        Task<TermometroEmocionalModel> UpdateTermometroEmocional(TermometroEmocionalModel termometroEmocional, int id);

        Task<bool> DeleteTermometroEmocional(int id);
    }
}
