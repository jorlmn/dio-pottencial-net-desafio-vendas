namespace tech_test_payment_api.Model
{
    public class Venda
    {
        public DateTime Data { get; set; }
        public int Id { get; set; }
        public List<Produto> ItensVendidos { get; set; }
        public Vendedor Vendedor { get; set; }
        public StatusVenda.Status StatusAtual { get; set; }

        public Venda(DateTime data, int id, List<Produto> itensVendidos, Vendedor vendedor, StatusVenda.Status statusAtual = StatusVenda.Status.Aguardando_Pagamento)
        {
            Data = data;
            Id = id;
            ItensVendidos = itensVendidos;
            Vendedor = vendedor;
            StatusAtual = statusAtual;
        }
    }
}   
