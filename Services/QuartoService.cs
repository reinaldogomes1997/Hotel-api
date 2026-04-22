using HotelApi.DTOs;
using HotelApi.Interfaces;
using HotelApi.Models;

namespace HotelApi.Services
{
    public class QuartoService : IQuartoService
    {
        private readonly IQuartoRepository _repository;

        public QuartoService(IQuartoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Quarto>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Quarto> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Create(QuartoDTO dto)
        {
            var quarto = new Quarto
            {
                Numero = dto.Numero,
                Tipo = dto.Tipo,
                Preco = dto.Preco,
                Disponivel = true
            };

            await _repository.Add(quarto);
        }

        public async Task Update(int id, QuartoDTO dto)
        {
            var quarto = await _repository.GetById(id);

            if (quarto == null)
                throw new Exception("Quarto não encontrado");

            quarto.Numero = dto.Numero;
            quarto.Tipo = dto.Tipo;
            quarto.Preco = dto.Preco;

            await _repository.Update(quarto);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}