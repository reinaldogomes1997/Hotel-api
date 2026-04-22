using System;

namespace HotelApi.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int QuartoId { get; set; }
        public Quarto Quarto { get; set; }

        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
    }
}