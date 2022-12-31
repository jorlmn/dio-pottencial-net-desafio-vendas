using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Model;

namespace tech_test_payment_api.Controllers;

[ApiController]
[Route("[controller]")]
public class VendasController : ControllerBase
{
    public static Dictionary<int, Venda> dictDeVendas = new();

    [HttpPost("RegistrarVenda")]
    public IActionResult RegistrarVenda(Venda venda)
    {
        // Rota que registra a venda caso ela não seja nula E
        // pelo menos 1 item seja vendido
        if (venda == null || venda.ItensVendidos.Count < 1)
        {
            return NotFound();
        }

        dictDeVendas[venda.Id] = venda;
        return Ok(dictDeVendas[venda.Id]);
    }

    [HttpGet("BuscarVenda/{id}")]
    public IActionResult BuscarVenda(int id)
    {
        // Rota que busca a venda conforme o ID
        if (!dictDeVendas.ContainsKey(id))
        {
            return NotFound();
        }

        return Ok(dictDeVendas[id]);
    }

    [HttpPut("AtualizarVenda")]
    public IActionResult AtualizarVenda(int id, StatusVenda.Status status)
    {
        // Rota que atualiza a venda correspondente ao ID com o status informado,
        // Mas primeiro checa se esta mudança de status da venda é válida
        
        if (!dictDeVendas.ContainsKey(id))
        {
            return NotFound();
        }
        else if (!StatusVenda.ValidacaoNovoStatus(status, dictDeVendas[id]))
        {
            return BadRequest("Não é possível fazer esta atualização de status");
        }

        dictDeVendas[id].StatusAtual = status;
        return Ok(dictDeVendas[id]);
    }
}
