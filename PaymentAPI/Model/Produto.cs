namespace tech_test_payment_api.Model
{
    public class Produto
    {
        public string Nome { get; set; }
        public int Id { get; set; }
        public decimal Valor { get; set; }

        public Produto(string nome, int id, decimal valor)
        {
            Nome = nome;
            Id = id;
            Valor = valor;
        }
    }
}