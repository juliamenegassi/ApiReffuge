using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class TermometroNoturnoRepositorio : ITermometroNoturnoRepositorio
    {
        private readonly Contexto _dbContext;

        public TermometroNoturnoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TermometroNoturnoModel>> GetAll()
        {
            return await _dbContext.TermometroNoturno.ToListAsync();
        }

        public async Task<TermometroNoturnoModel> GetById(int id)
        {
            return await _dbContext.TermometroNoturno.FirstOrDefaultAsync(x => x.TermometroNoturnoId == id);
        }

        public async Task<TermometroNoturnoModel> InsertTermometroNoturno(TermometroNoturnoModel termometroNoturno)
        {
            await _dbContext.TermometroNoturno.AddAsync(termometroNoturno);
            await _dbContext.SaveChangesAsync();
            return termometroNoturno;
        }

        public async Task<TermometroNoturnoModel> UpdateTermometroNoturno(TermometroNoturnoModel termometroNoturno, int id)
        {
            TermometroNoturnoModel termometrosNoturnos = await GetById(id);
            if (termometrosNoturnos == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                termometrosNoturnos.Data = termometroNoturno.Data;
                termometrosNoturnos.DuracaoSonoId = termometroNoturno.DuracaoSonoId;
                termometrosNoturnos.VezesAcordou = termometroNoturno.VezesAcordou;
                termometrosNoturnos.TipoSentimentoSonoId = termometroNoturno.TipoSentimentoSonoId;
                termometrosNoturnos.ClienteId = termometroNoturno.ClienteId;
                _dbContext.TermometroNoturno.Update(termometrosNoturnos);
                await _dbContext.SaveChangesAsync();
            }
            return termometrosNoturnos;

        }

        public async Task<bool> DeleteTermometroNoturno(int id)
        {
            TermometroNoturnoModel termometroNoturno = await GetById(id);
            if (termometroNoturno == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.TermometroNoturno.Remove(termometroNoturno);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
