using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class PlanosRepositorio : IPlanosRepositorio
    {
        private readonly Contexto _dbContext;

        public PlanosRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PlanosModel>> GetAll()
        {
            return await _dbContext.Planos.ToListAsync();
        }

        public async Task<PlanosModel> GetById(int id)
        {
            return await _dbContext.Planos.FirstOrDefaultAsync(x => x.PlanosId == id);
        }

        public async Task<PlanosModel> InsertPlanos(PlanosModel planos)
        {
            await _dbContext.Planos.AddAsync(planos);
            await _dbContext.SaveChangesAsync();
            return planos;
        }

        public async Task<PlanosModel> UpdatePlanos(PlanosModel planos, int id)
        {
            PlanosModel plano = await GetById(id);
            if (plano == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                plano.NomePlanos = planos.NomePlanos;
                plano.PrecoPlanos = planos.PrecoPlanos;
                plano.DescricaoPlanos = planos.DescricaoPlanos;
                plano.DuracaoPlanos = planos.DuracaoPlanos;
                _dbContext.Planos.Update(plano);
                await _dbContext.SaveChangesAsync();
            }
            return plano;

        }

        public async Task<bool> DeletePlanos(int id)
        {
            PlanosModel planos = await GetById(id);
            if (planos == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Planos.Remove(planos);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
