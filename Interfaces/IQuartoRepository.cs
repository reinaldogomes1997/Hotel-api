using HotelApi.Models;

namespace HotelApi.Interfaces
{
    public interface IQuartoRepository
    {
        Task<List<Quarto>> GetAll();
        Task<Quarto> GetById(int id);
        Task Add(Quarto quarto);
        Task Update(Quarto quarto);
        Task Delete(int id);
    }
}