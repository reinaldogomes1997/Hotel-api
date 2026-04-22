using HotelApi.DTOs;
using HotelApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClientesController(IClienteService service)
        {
            _service = service;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clientes = await _service.GetAll();
            return Ok(clientes);
        }

        // GET: api/Clientes/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _service.GetById(id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        // POST: api/Clientes
        [HttpPost]
        public async Task<IActionResult> Post(ClienteDTO dto)
        {
            await _service.Create(dto);
            return Ok("Cliente criado com sucesso");
        }

        // PUT: api/Clientes/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ClienteDTO dto)
        {
            await _service.Update(id, dto);
            return NoContent();
        }

        // DELETE: api/Clientes/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}