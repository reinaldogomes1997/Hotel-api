using HotelApi.DTOs;
using HotelApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuartosController : ControllerBase
    {
        private readonly IQuartoService _service;

        public QuartosController(IQuartoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var quartos = await _service.GetAll();
            return Ok(quartos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var quarto = await _service.GetById(id);

            if (quarto == null)
                return NotFound();

            return Ok(quarto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(QuartoDTO dto)
        {
            await _service.Create(dto);
            return Ok("Quarto criado com sucesso");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, QuartoDTO dto)
        {
            await _service.Update(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}