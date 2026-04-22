using HotelApi.Data;
using HotelApi.Interfaces;
using HotelApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Repositories
{
    public class QuartoRepository : IQuartoRepository
    {
        private readonly AppDbContext _context;

        public QuartoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Quarto>> GetAll()
        {
            return await _context.Quartos
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Quarto> GetById(int id)
        {
            return await _context.Quartos.FindAsync(id);
        }

        public async Task Add(Quarto quarto)
        {
            await _context.Quartos.AddAsync(quarto);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Quarto quarto)
        {
            _context.Quartos.Update(quarto);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var quarto = await _context.Quartos.FindAsync(id);

            if (quarto != null)
            {
                _context.Quartos.Remove(quarto);
                await _context.SaveChangesAsync();
            }
        }
    }
}