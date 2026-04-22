using HotelApi.DTOs;
using HotelApi.Models;

namespace HotelApi.Interfaces
{
    public interface IQuartoService
    {
        Task<List<Quarto>> GetAll();
        Task<Quarto> GetById(int id);
        Task Create(QuartoDTO dto);
        Task Update(int id, QuartoDTO dto);
        Task Delete(int id);
    }
}