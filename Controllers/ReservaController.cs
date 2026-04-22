using HotelApi.DTOs;
using HotelApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {
        private readonly IReservaService _service;

        public ReservasController(IReservaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Post(ReservaDTO dto)
        {
            await _service.Create(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}