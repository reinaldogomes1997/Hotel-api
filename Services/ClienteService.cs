using HotelApi.DTOs;
using HotelApi.Interfaces;
using HotelApi.Models;
using HotelApi.Repositories;

namespace HotelApi.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Cliente>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task Create(ClienteDTO dto)
        {
            var cliente = new Cliente
            {
                Nome = dto.Nome,
                Email = dto.Email
            };

            await _repository.Add(cliente);
        }

        public async Task Update(int id, ClienteDTO dto)
        {
            var cliente = await _repository.GetById(id);

            if (cliente == null)
                throw new Exception("Cliente não encontrado");

            cliente.Nome = dto.Nome;
            cliente.Email = dto.Email;

            await _repository.Update(cliente);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}