## PROJETO PARA TESTE TÉCNICO - POTTENCIAL .NET DEVELOPER

API REST .NET de Registro de Vendas. O projeto do desafio é tech-test-payment-api, que contém três operações: Registrar Venda, Buscar Venda; e Atualizar Venda. A API não implementa mecanismos de persistência em banco de dados, conforme as diretrizes do desafio. Assim, os dados das vendas são guardados na memória, em listas. Além de ter documentação Swagger, há um projeto separado para realizar testes unitários na API.

## TESTES UNITÁRIOS USANDO XUNIT
Projeto PaymentAPI.Test engloba os testes unitários realizados usando Xunit. Possui testes da lógica e dos métodos usados nas operações do projeto principal. Posto que não é utilizado um banco de dados, define-se uma série de variáveis static para serem utilizadas nos testes.

## DOCUMENTAÇÃO
API apresenta documentação Swagger ao ser executada no modo desenvolvedor.

## MELHORIAS
- Implementação completa do CRUD
- Utilizar Entity Framework para o uso de banco de dados

