using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface ITermometroNoturnoRepositorio
    {
        Task<List<TermometroNoturnoModel>> GetAll();

        Task<TermometroNoturnoModel> GetById(int id);

        Task<TermometroNoturnoModel> InsertTermometroNoturno(TermometroNoturnoModel termometroNoturno);

        Task<TermometroNoturnoModel> UpdateTermometroNoturno(TermometroNoturnoModel termometroNoturno, int id);

        Task<bool> DeleteTermometroNoturno(int id);
    }
}
