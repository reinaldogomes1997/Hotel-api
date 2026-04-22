namespace HotelApi.Models
{
    public class Quarto
    {
        public int Id { get; set; }

        public string Numero { get; set; }

        public string Tipo { get; set; }

        public decimal Preco { get; set; }

        public bool Disponivel { get; set; }
    }
}
