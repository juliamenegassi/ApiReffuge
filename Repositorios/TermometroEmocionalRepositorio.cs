using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class TermometroEmocionalRepositorio : ITermometroEmocionalRepositorio
    {
            private readonly Contexto _dbContext;

            public TermometroEmocionalRepositorio(Contexto dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<List<TermometroEmocionalModel>> GetAll()
            {
                return await _dbContext.TermometroEmocional.ToListAsync();
            }

            public async Task<TermometroEmocionalModel> GetById(int id)
            {
                return await _dbContext.TermometroEmocional.FirstOrDefaultAsync(x => x.TermometroEmocionalId == id);
            }

            public async Task<TermometroEmocionalModel> InsertTermometroEmocional(TermometroEmocionalModel termometroEmocional)
            {
                await _dbContext.TermometroEmocional.AddAsync(termometroEmocional);
                await _dbContext.SaveChangesAsync();
                return termometroEmocional;
            }

            public async Task<TermometroEmocionalModel> UpdateTermometroEmocional(TermometroEmocionalModel termometroEmocional, int id)
            {
                TermometroEmocionalModel termometrosEmocionais = await GetById(id);
                if (termometrosEmocionais == null)
                {
                    throw new Exception("Não encontrado.");
                }
                else
                {
                    termometrosEmocionais.TipoEmocaoId = termometroEmocional.TipoEmocaoId;
                    termometrosEmocionais.ClienteId = termometroEmocional.ClienteId;
                    termometrosEmocionais.Data = termometroEmocional.Data;
                    _dbContext.TermometroEmocional.Update(termometrosEmocionais);
                    await _dbContext.SaveChangesAsync();
                }
                return termometrosEmocionais;

            }

            public async Task<bool> DeleteTermometroEmocional(int id)
            {
                TermometroEmocionalModel termometroEmocional = await GetById(id);
                if (termometroEmocional == null)
                {
                    throw new Exception("Não encontrado.");
                }

                _dbContext.TermometroEmocional.Remove(termometroEmocional);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }
}
