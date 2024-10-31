using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class DuracaoSonoRepositorio : IDuracaoSonoRepositorio
    {
        private readonly Contexto _dbContext;

        public DuracaoSonoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DuracaoSonoModel>> GetAll()
        {
            return await _dbContext.DuracaoSono.ToListAsync();
        }

        public async Task<DuracaoSonoModel> GetById(int id)
        {
            return await _dbContext.DuracaoSono.FirstOrDefaultAsync(x => x.DuracaoSonoId == id);
        }

        public async Task<DuracaoSonoModel> InsertDuracaoSono(DuracaoSonoModel duracaoSono)
        {
            await _dbContext.DuracaoSono.AddAsync(duracaoSono);
            await _dbContext.SaveChangesAsync();
            return duracaoSono;
        }

        public async Task<DuracaoSonoModel> UpdateDuracaoSono(DuracaoSonoModel duracaoSono, int id)
        {
            DuracaoSonoModel duracaoSonos = await GetById(id);
            if (duracaoSonos == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                duracaoSonos.NomeDuracaoSono = duracaoSono.NomeDuracaoSono;
                _dbContext.DuracaoSono.Update(duracaoSonos);
                await _dbContext.SaveChangesAsync();
            }
            return duracaoSonos;

        }

        public async Task<bool> DeleteDuracaoSono(int id)
        {
            DuracaoSonoModel duracaoSono = await GetById(id);
            if (duracaoSono == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.DuracaoSono.Remove(duracaoSono);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
