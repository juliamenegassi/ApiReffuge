using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class ProfissionalRepositorio : IProfissionalRepositorio
    {
        private readonly Contexto _dbContext;

        public ProfissionalRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProfissionalModel>> GetAll()
        {
            return await _dbContext.Profissional.ToListAsync();
        }

        public async Task<ProfissionalModel> GetById(int id)
        {
            return await _dbContext.Profissional.FirstOrDefaultAsync(x => x.ProfissionalId == id);
        }

        public async Task<ProfissionalModel> InsertProfissional(ProfissionalModel profissional)
        {
            await _dbContext.Profissional.AddAsync(profissional);
            await _dbContext.SaveChangesAsync();
            return profissional;
        }

        public async Task<ProfissionalModel> UpdateProfissional(ProfissionalModel profissional, int id)
        {
            ProfissionalModel profissionais = await GetById(id);
            if (profissionais == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                profissionais.FotoProfissional = profissional.FotoProfissional;
                profissionais.NomeProfissional = profissional.NomeProfissional;            
                profissionais.TipoEspecializacaoId = profissional.TipoEspecializacaoId;
                profissionais.DescricaoProfissional = profissional.DescricaoProfissional;
                _dbContext.Profissional.Update(profissionais);
                await _dbContext.SaveChangesAsync();
            }
            return profissionais;

        }

        public async Task<bool> DeleteProfissional(int id)
        {
            ProfissionalModel profissional = await GetById(id);
            if (profissional == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Profissional.Remove(profissional);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
