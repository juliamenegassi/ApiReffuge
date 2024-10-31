using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class TipoEspecializacaoRepositorio : ITipoEspecializacaoRepositorio
    {
        private readonly Contexto _dbContext;

        public TipoEspecializacaoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TipoEspecializacaoModel>> GetAll()
        {
            return await _dbContext.TipoEspecializacao.ToListAsync();
        }

        public async Task<TipoEspecializacaoModel> GetById(int id)
        {
            return await _dbContext.TipoEspecializacao.FirstOrDefaultAsync(x => x.TipoEspecializacaoId == id);
        }

        public async Task<TipoEspecializacaoModel> InsertTipoEspecializacao(TipoEspecializacaoModel tipoEspecializacao)
        {
            await _dbContext.TipoEspecializacao.AddAsync(tipoEspecializacao);
            await _dbContext.SaveChangesAsync();
            return tipoEspecializacao;
        }

        public async Task<TipoEspecializacaoModel> UpdateTipoEspecializacao(TipoEspecializacaoModel tipoEspecializacao, int id)
        {
            TipoEspecializacaoModel tipoEspecializacoes = await GetById(id);
            if (tipoEspecializacoes == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                tipoEspecializacoes.NomeTipoEspecializacao = tipoEspecializacao.NomeTipoEspecializacao;
                _dbContext.TipoEspecializacao.Update(tipoEspecializacoes);
                await _dbContext.SaveChangesAsync();
            }
            return tipoEspecializacoes;
        }

        public async Task<bool> DeleteTipoEspecializacao(int id)
        {
            TipoEspecializacaoModel tipoEspecializacao = await GetById(id);
            if (tipoEspecializacao == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.TipoEspecializacao.Remove(tipoEspecializacao);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
