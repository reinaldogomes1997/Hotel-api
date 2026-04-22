public class ReservaResponseDTO
{
    public int Id { get; set; }

    public string NomeCliente { get; set; }
    public string EmailCliente { get; set; }

    public string NumeroQuarto { get; set; }
    public string TipoQuarto { get; set; }
    public decimal Preco { get; set; }

    public DateTime DataEntrada { get; set; }
    public DateTime DataSaida { get; set; }
}