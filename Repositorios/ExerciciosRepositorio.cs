using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class ExerciciosRepositorio : IExerciciosRepositorio
    {
        private readonly Contexto _dbContext;

        public ExerciciosRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ExerciciosModel>> GetAll()
        {
            return await _dbContext.Exercicios.ToListAsync();
        }

        public async Task<ExerciciosModel> GetById(int id)
        {
            return await _dbContext.Exercicios.FirstOrDefaultAsync(x => x.ExerciciosId == id);
        }

        public async Task<ExerciciosModel> InsertExercicios(ExerciciosModel exercicios)
        {
            await _dbContext.Exercicios.AddAsync(exercicios);
            await _dbContext.SaveChangesAsync();
            return exercicios;
        }

        public async Task<ExerciciosModel> UpdateExercicios(ExerciciosModel exercicios, int id)
        {
            ExerciciosModel exercicio = await GetById(id);
            if (exercicio == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                exercicio.NomeExercicios = exercicios.NomeExercicios;
                exercicio.TipoExerciciosId = exercicios.TipoExerciciosId;
                _dbContext.Exercicios.Update(exercicio);
                await _dbContext.SaveChangesAsync();
            }
            return exercicio;

        }

        public async Task<bool> DeleteExercicios(int id)
        {
            ExerciciosModel exercicios = await GetById(id);
            if (exercicios == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Exercicios.Remove(exercicios);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
