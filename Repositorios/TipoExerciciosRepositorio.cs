using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class TipoExerciciosRepositorio : ITipoExerciciosRepositorio
    {
        private readonly Contexto _dbContext;

        public TipoExerciciosRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TipoExerciciosModel>> GetAll()
        {
            return await _dbContext.TipoExercicios.ToListAsync();
        }

        public async Task<TipoExerciciosModel> GetById(int id)
        {
            return await _dbContext.TipoExercicios.FirstOrDefaultAsync(x => x.TipoExerciciosId == id);
        }

        public async Task<TipoExerciciosModel> InsertTipoExercicios(TipoExerciciosModel tipoExercicios)
        {
            await _dbContext.TipoExercicios.AddAsync(tipoExercicios);
            await _dbContext.SaveChangesAsync();
            return tipoExercicios;
        }

        public async Task<TipoExerciciosModel> UpdateTipoExercicios(TipoExerciciosModel tipoExercicios, int id)
        {
            TipoExerciciosModel tipoExercicio = await GetById(id);
            if (tipoExercicio == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                tipoExercicio.NomeTipoExercicios = tipoExercicios.NomeTipoExercicios;
                _dbContext.TipoExercicios.Update(tipoExercicio);
                await _dbContext.SaveChangesAsync();
            }
            return tipoExercicio;

        }

        public async Task<bool> DeleteTipoExercicios(int id)
        {
            TipoExerciciosModel tipoExercicios = await GetById(id);
            if (tipoExercicios == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.TipoExercicios.Remove(tipoExercicios);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
