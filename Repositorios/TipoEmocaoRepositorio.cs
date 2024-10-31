using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class TipoEmocaoRepositorio : ITipoEmocaoRepositorio
    {
        private readonly Contexto _dbContext;
        public TipoEmocaoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TipoEmocaoModel>> GetAll()
        {
            return await _dbContext.TipoEmocao.ToListAsync();
        }

        public async Task<TipoEmocaoModel> GetById(int id)
        {
            return await _dbContext.TipoEmocao.FirstOrDefaultAsync(x => x.TipoEmocaoId == id);
        }

        public async Task<TipoEmocaoModel> InsertTipoEmocao(TipoEmocaoModel tipoEmocao)
        {
            await _dbContext.TipoEmocao.AddAsync(tipoEmocao);
            await _dbContext.SaveChangesAsync();
            return tipoEmocao;
        }

        public async Task<TipoEmocaoModel> UpdateTipoEmocao(TipoEmocaoModel tipoEmocao, int id)
        {
            TipoEmocaoModel tipoEmocoes = await GetById(id);
            if (tipoEmocoes == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                tipoEmocoes.NomeTipoEmocao = tipoEmocao.NomeTipoEmocao;
                _dbContext.TipoEmocao.Update(tipoEmocoes);
                await _dbContext.SaveChangesAsync();
            }
            return tipoEmocoes;

        }

        public async Task<bool> DeleteTipoEmocao(int id)
        {
            TipoEmocaoModel tipoEmocao = await GetById(id);
            if (tipoEmocao == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.TipoEmocao.Remove(tipoEmocao);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
