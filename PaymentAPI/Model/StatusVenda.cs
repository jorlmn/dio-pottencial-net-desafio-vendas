namespace tech_test_payment_api.Model
{
    public class StatusVenda
    {
        public enum Status {
        Aguardando_Pagamento,
        Pagamento_Aprovado,
        Enviado_Para_Transportadora,
        Entregue,
        Cancelada
        }

        public static bool ValidacaoNovoStatus(Status novoStatus, Venda venda)
        {
            bool atualizacaoValida = false;

            switch (novoStatus)
            {
                case Status.Cancelada:
                    if (venda.StatusAtual == Status.Pagamento_Aprovado ||
                    venda.StatusAtual == Status.Aguardando_Pagamento)
                    {
                        atualizacaoValida = true;
                    }
                    break;

                case Status.Pagamento_Aprovado:
                    if (venda.StatusAtual == Status.Aguardando_Pagamento)
                    {
                        atualizacaoValida = true;
                    }
                    break;
                
                case Status.Enviado_Para_Transportadora:
                    if (venda.StatusAtual == Status.Pagamento_Aprovado)
                    {
                        atualizacaoValida = true;
                    }
                    break;

                case Status.Entregue:
                    if (venda.StatusAtual == Status.Enviado_Para_Transportadora)
                    {
                        atualizacaoValida = true;
                    }
                    break;
                
                default:
                    atualizacaoValida = false;
                    break;
            }

            return atualizacaoValida;
        }
    }
}