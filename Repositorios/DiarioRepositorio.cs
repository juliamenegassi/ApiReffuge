using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class DiarioRepositorio : IDiarioRepositorio
    {
        private readonly Contexto _dbContext;

        public DiarioRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DiarioModel>> GetAll()
        {
            return await _dbContext.Diario.ToListAsync();
        }

        public async Task<DiarioModel> GetById(int id)
        {
            return await _dbContext.Diario.FirstOrDefaultAsync(x => x.DiarioId == id);
        }

        public async Task<DiarioModel> InsertDiario(DiarioModel diario)
        {
            await _dbContext.Diario.AddAsync(diario);
            await _dbContext.SaveChangesAsync();
            return diario;
        }

        public async Task<DiarioModel> UpdateDiario(DiarioModel diario, int id)
        {
            DiarioModel diarios = await GetById(id);
            if (diarios == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                diarios.DataHorario = diario.DataHorario;
                diarios.ConteudoDiario = diario.ConteudoDiario;
                diarios.ClienteId = diario.ClienteId;
                _dbContext.Diario.Update(diarios);
                await _dbContext.SaveChangesAsync();
            }
            return diarios;

        }

        public async Task<bool> DeleteDiario(int id)
        {
            DiarioModel diario = await GetById(id);
            if (diario == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Diario.Remove(diario);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
