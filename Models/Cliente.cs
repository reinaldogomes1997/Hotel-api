using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }
    }
}