using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class TipoSentimentoSonoRepositorio : ITipoSentimentoSonoRepositorio
    {
        private readonly Contexto _dbContext;

        public TipoSentimentoSonoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TipoSentimentoSonoModel>> GetAll()
        {
            return await _dbContext.TipoSentimentoSono.ToListAsync();
        }

        public async Task<TipoSentimentoSonoModel> GetById(int id)
        {
            return await _dbContext.TipoSentimentoSono.FirstOrDefaultAsync(x => x.TipoSentimentoSonoId == id);
        }

        public async Task<TipoSentimentoSonoModel> InsertTipoSentimentoSono(TipoSentimentoSonoModel tipoSentimentoSono)
        {
            await _dbContext.TipoSentimentoSono.AddAsync(tipoSentimentoSono);
            await _dbContext.SaveChangesAsync();
            return tipoSentimentoSono;
        }

        public async Task<TipoSentimentoSonoModel> UpdateTipoSentimentoSono(TipoSentimentoSonoModel tipoSentimentoSono, int id)
        {
            TipoSentimentoSonoModel tipoSentimentoSonos = await GetById(id);
            if (tipoSentimentoSonos == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                tipoSentimentoSonos.NomeTipoSentimentoSono = tipoSentimentoSono.NomeTipoSentimentoSono;
                _dbContext.TipoSentimentoSono.Update(tipoSentimentoSonos);
                await _dbContext.SaveChangesAsync();
            }
            return tipoSentimentoSonos;

        }

        public async Task<bool> DeleteTipoSentimentoSono(int id)
        {
            TipoSentimentoSonoModel tipoSentimentoSono = await GetById(id);
            if (tipoSentimentoSono == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.TipoSentimentoSono.Remove(tipoSentimentoSono);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
