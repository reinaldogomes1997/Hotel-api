using HotelApi.DTOs;

namespace HotelApi.Interfaces
{
    public interface IReservaService
    {
        Task<List<ReservaResponseDTO>> GetAll();
        Task<ReservaResponseDTO?> GetById(int id);
        Task Create(ReservaDTO dto);
        Task Delete(int id);
    }
}