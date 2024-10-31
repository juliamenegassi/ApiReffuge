using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class AgendamentoRepositorio : IAgendamentoRepositorio
    {
        private readonly Contexto _dbContext;

        public AgendamentoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AgendamentoModel>> GetAll()
        {
            return await _dbContext.Agendamento.ToListAsync();
        }

        public async Task<AgendamentoModel> GetById(int id)
        {
            return await _dbContext.Agendamento.FirstOrDefaultAsync(x => x.AgendamentoId == id);
        }

        public async Task<AgendamentoModel> InsertAgendamento(AgendamentoModel agendamento)
        {
            await _dbContext.Agendamento.AddAsync(agendamento);
            await _dbContext.SaveChangesAsync();
            return agendamento;
        }

        public async Task<AgendamentoModel> UpdateAgendamento(AgendamentoModel requisicao, int id)
        {
            AgendamentoModel agendamento = await GetById(id);
            if (agendamento == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                agendamento.ClienteId = requisicao.ClienteId;
                agendamento.DataHora = requisicao.DataHora;
                agendamento.ProfissionalId = requisicao.ProfissionalId;
                _dbContext.Agendamento.Update(agendamento);
                await _dbContext.SaveChangesAsync();
            }
            return agendamento;

        }

        public async Task<bool> DeleteAgendamento(int id)
        {
            AgendamentoModel agendamento = await GetById(id);
            if (agendamento == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Agendamento.Remove(agendamento);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
