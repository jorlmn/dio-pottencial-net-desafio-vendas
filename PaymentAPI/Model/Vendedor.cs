namespace tech_test_payment_api.Model
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Cpf { get; set; }
        public int Telefone { get; set; }
        public string Email { get; set; }

        public Vendedor(int id, string nome, int cpf, int telefone, string email)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Email = email;
        }
    }
}