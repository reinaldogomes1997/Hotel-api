using HotelApi.Data;
using HotelApi.Interfaces;
using HotelApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> GetAll()
        {
            return await _context.Clientes
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task Add(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}