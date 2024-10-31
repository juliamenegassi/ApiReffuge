using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly Contexto _dbContext;

        public ClienteRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ClienteModel>> GetAll()
        {
            return await _dbContext.Cliente.ToListAsync();
        }

        public async Task<ClienteModel> GetById(int id)
        {
            return await _dbContext.Cliente.FirstOrDefaultAsync(x => x.ClienteId == id);
        }

        public async Task<ClienteModel> InsertCliente(ClienteModel cliente)
        {
            await _dbContext.Cliente.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();
            return cliente;
        }

        public async Task<ClienteModel> UpdateCliente(ClienteModel cliente, int id)
        {
            ClienteModel clientes = await GetById(id);
            if (clientes == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                clientes.NomeCliente = cliente.NomeCliente;
                clientes.FotoCliente = cliente.FotoCliente;
                clientes.CpfCliente = cliente.CpfCliente;
                clientes.TelefoneCliente = cliente.TelefoneCliente;
                clientes.EmailCliente = cliente.EmailCliente;
                clientes.SenhaCliente = cliente.SenhaCliente;
                clientes.PlanosId = cliente.PlanosId;
                _dbContext.Cliente.Update(clientes);
                await _dbContext.SaveChangesAsync();
            }
            return clientes;

        }

        public async Task<bool> DeleteCliente(int id)
        {
            ClienteModel cliente = await GetById(id);
            if (cliente == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Cliente.Remove(cliente);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
