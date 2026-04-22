using HotelApi.Models;

namespace HotelApi.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetAll();
        Task<Cliente> GetById(int id);
        Task Add(Cliente cliente);
        Task Update(Cliente cliente);
        Task Delete(int id);
    }
}