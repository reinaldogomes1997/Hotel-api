using HotelApi.Data;
using HotelApi.DTOs;
using HotelApi.Interfaces;
using HotelApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Services
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _repository;
        private readonly AppDbContext _context;

        public ReservaService(IReservaRepository repository, AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        // 🔥 GET ALL COM DTO (PROFISSIONAL)
        public async Task<List<ReservaResponseDTO>> GetAll()
        {
            var reservas = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Quarto)
                .ToListAsync();

            return reservas.Select(r => new ReservaResponseDTO
            {
                Id = r.Id,
                NomeCliente = r.Cliente.Nome,
                EmailCliente = r.Cliente.Email,
                NumeroQuarto = r.Quarto.Numero,
                TipoQuarto = r.Quarto.Tipo,
                Preco = r.Quarto.Preco,
                DataEntrada = r.DataEntrada,
                DataSaida = r.DataSaida
            }).ToList();
        }

        // 🔥 GET BY ID COM DTO
        public async Task<ReservaResponseDTO?> GetById(int id)
        {
            var reserva = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Quarto)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reserva == null)
                return null;

            return new ReservaResponseDTO
            {
                Id = reserva.Id,
                NomeCliente = reserva.Cliente.Nome,
                EmailCliente = reserva.Cliente.Email,
                NumeroQuarto = reserva.Quarto.Numero,
                TipoQuarto = reserva.Quarto.Tipo,
                Preco = reserva.Quarto.Preco,
                DataEntrada = reserva.DataEntrada,
                DataSaida = reserva.DataSaida
            };
        }

        // 🔥 CREATE (MANTIDO + VALIDADO)
        public async Task Create(ReservaDTO dto)
        {
            // 1. Validar datas
            if (dto.DataSaida <= dto.DataEntrada)
                throw new Exception("Data de saída deve ser maior que a entrada");

            // 2. Verificar cliente
            var cliente = await _context.Clientes.FindAsync(dto.ClienteId);
            if (cliente == null)
                throw new Exception("Cliente não encontrado");

            // 3. Verificar quarto
            var quarto = await _context.Quartos.FindAsync(dto.QuartoId);
            if (quarto == null)
                throw new Exception("Quarto não encontrado");

            // 4. Verificar conflito
            var conflito = await _context.Reservas.AnyAsync(r =>
                r.QuartoId == dto.QuartoId &&
                dto.DataEntrada < r.DataSaida &&
                dto.DataSaida > r.DataEntrada
            );

            if (conflito)
                throw new Exception("Quarto já reservado nesse período");

            // 5. Criar reserva
            var reserva = new Reserva
            {
                ClienteId = dto.ClienteId,
                QuartoId = dto.QuartoId,
                DataEntrada = dto.DataEntrada,
                DataSaida = dto.DataSaida
            };

            await _repository.Add(reserva);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}