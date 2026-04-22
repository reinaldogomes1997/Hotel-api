using HotelApi.DTOs;
using HotelApi.Models;

namespace HotelApi.Interfaces
{
    public interface IClienteService
    {
        Task<List<Cliente>> GetAll();
        Task<Cliente> GetById(int id);
        Task Create(ClienteDTO dto);
        Task Update(int id, ClienteDTO dto);
        Task Delete(int id);
    }
}