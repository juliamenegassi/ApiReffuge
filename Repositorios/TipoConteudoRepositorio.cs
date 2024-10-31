using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class TipoConteudoRepositorio : ITipoConteudoRepositorio
    {
        private readonly Contexto _dbContext;

        public TipoConteudoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TipoConteudoModel>> GetAll()
        {
            return await _dbContext.TipoConteudo.ToListAsync();
        }

        public async Task<TipoConteudoModel> GetById(int id)
        {
            return await _dbContext.TipoConteudo.FirstOrDefaultAsync(x => x.TipoConteudoId == id);
        }

        public async Task<TipoConteudoModel> InsertTipoConteudo(TipoConteudoModel tipoConteudo)
        {
            await _dbContext.TipoConteudo.AddAsync(tipoConteudo);
            await _dbContext.SaveChangesAsync();
            return tipoConteudo;
        }

        public async Task<TipoConteudoModel> UpdateTipoConteudo(TipoConteudoModel tipoConteudo, int id)
        {
            TipoConteudoModel tipoConteudos = await GetById(id);
            if (tipoConteudos == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                tipoConteudos.NomeTipoConteudo = tipoConteudo.NomeTipoConteudo;
                _dbContext.TipoConteudo.Update(tipoConteudos);
                await _dbContext.SaveChangesAsync();
            }
            return tipoConteudos;

        }

        public async Task<bool> DeleteTipoConteudo(int id)
        {
            TipoConteudoModel tipoConteudo = await GetById(id);
            if (tipoConteudo == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.TipoConteudo.Remove(tipoConteudo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
