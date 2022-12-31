using tech_test_payment_api.Model;

namespace PaymentAPI.Test;

public class Payment_Tests
{
    static List<Produto> itens0Teste = new List<Produto> 
    {
        new Produto("Geladeira", 0, 200m), 
        new Produto("Carro", 1, 20000m)
    };
    static List<Produto> itens1Teste = new List<Produto> 
    {
        new Produto("Computador", 2, 1000m)
    };
    static List<Produto> itens2teste = new();

    static Vendedor vendedor0Teste = new Vendedor(0, "Juan", 123123123, 55555555, "email@email");
    static Vendedor vendedor1Teste = new Vendedor(1, "Edson", 11111111, 99999999, "meuemail@e.com");
    static Vendedor vendedor2Teste = new Vendedor(2, "Gabriel", 515151515, 22222222, "wasd@e.wad");

    static Dictionary<int, Venda> dictVendasTeste = new Dictionary<int, Venda> {
        {0, new Venda(DateTime.Now, 0, itens0Teste, vendedor0Teste, StatusVenda.Status.Aguardando_Pagamento)},
        {1, new Venda(DateTime.Now, 1, itens1Teste, vendedor1Teste, StatusVenda.Status.Enviado_Para_Transportadora)},
        {2, new Venda(DateTime.Now, 2, itens2teste, vendedor2Teste, StatusVenda.Status.Aguardando_Pagamento)}
    };

    [Theory]
    [InlineData(false, StatusVenda.Status.Entregue, 0)]
    [InlineData(true, StatusVenda.Status.Cancelada, 0)]
    [InlineData(true, StatusVenda.Status.Pagamento_Aprovado, 0)]
    [InlineData(false, StatusVenda.Status.Aguardando_Pagamento, 0)]
    [InlineData(false, StatusVenda.Status.Enviado_Para_Transportadora, 0)]
    [InlineData(false, StatusVenda.Status.Cancelada, 1)]
    [InlineData(true, StatusVenda.Status.Entregue, 1)]
    [InlineData(false, StatusVenda.Status.Pagamento_Aprovado, 1)]
    public void AlterarStatus_TesteValidez(bool expected, StatusVenda.Status statusTest, int id)
    {
        Assert.Equal(expected, StatusVenda.ValidacaoNovoStatus(statusTest, dictVendasTeste[id]));
    }

    [Theory]
    [InlineData(true, 0)]
    [InlineData(true, 1)]   
    [InlineData(false, 2)]
    [InlineData(false, 3)]
    public void RegistrarVenda_TesteQuantidadeItens(bool expected, int id)
    {
        Venda vendaTestada = dictVendasTeste.ContainsKey(id) ? dictVendasTeste[id] : null;

        Assert.Equal(expected, vendaTestada != null && vendaTestada.ItensVendidos.Count >= 1);
    }

    [Theory]
    [InlineData(true, 0)]
    [InlineData(true, 1)]   
    [InlineData(false, 3)]
    public void BuscarVenda_TestePorId(bool expected, int id)
    {
        Assert.Equal(expected, dictVendasTeste.ContainsKey(id));
    }
}