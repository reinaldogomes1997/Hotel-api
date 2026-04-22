using HotelApi.Data;
using HotelApi.Interfaces;
using HotelApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly AppDbContext _context;

        public ReservaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reserva>> GetAll()
        {
            return await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Quarto)
                .ToListAsync();
        }

        public async Task<Reserva> GetById(int id)
        {
            return await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Quarto)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task Add(Reserva reserva)
        {
            await _context.Reservas.AddAsync(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);

            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
                await _context.SaveChangesAsync();
            }
        }
    }
}