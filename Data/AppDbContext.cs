using Microsoft.EntityFrameworkCore;
using HotelApi.Models;

namespace HotelApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Quarto> Quartos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
    }
}