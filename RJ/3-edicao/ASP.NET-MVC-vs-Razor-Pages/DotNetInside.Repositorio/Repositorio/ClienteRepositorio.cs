using DotNetInside.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DotNetInside.Repositorio
{
    public class ClienteRepositorio
    {
        private readonly ContextoBd _contextoBD;

        public ClienteRepositorio() { }

        public ClienteRepositorio(ContextoBd contextoBD)
        {
            _contextoBD = contextoBD;
        }

        public async Task<List<Cliente>> RecuperarClientes()
        {
            return await _contextoBD.Clientes.OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task<Cliente> RecuperarClienteId(int id)
        {
            return await _contextoBD.Clientes.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Incluir(Cliente cliente)
        {
            _contextoBD.Clientes.Add(cliente);
            return (await _contextoBD.SaveChangesAsync() > 0);
        }

        public async Task<bool> Alterar(Cliente cliente)
        {
            _contextoBD.Clientes.Update(cliente);
            return (await _contextoBD.SaveChangesAsync() > 0);
        }

        public async Task<bool> Excluir(Cliente cliente)
        {
            _contextoBD.Clientes.Remove(cliente);
            return (await _contextoBD.SaveChangesAsync() > 0);
        }
    }
}