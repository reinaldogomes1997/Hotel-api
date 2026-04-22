using HotelApi.Models;

namespace HotelApi.Interfaces
{
    public interface IReservaRepository
    {
        Task<List<Reserva>> GetAll();
        Task<Reserva> GetById(int id);
        Task Add(Reserva reserva);
        Task Delete(int id);
    }
}