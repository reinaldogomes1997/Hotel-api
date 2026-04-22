using System.ComponentModel.DataAnnotations;

namespace HotelApi.DTOs
{
    public class ClienteDTO
    {
        [Required]
        public string Nome { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}