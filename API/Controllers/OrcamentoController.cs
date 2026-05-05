using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Domain.DTOs;

namespace API.Controllers;

[ApiController]
[Route("api/orcamentos")]
public class OrcamentoController : ControllerBase
{
    private readonly OrcamentoService _service;

    public OrcamentoController()
    {
        _service = new OrcamentoService();
    }

    [HttpPost]
    public IActionResult Criar([FromBody] CriarOrcamentoRequest request)
    {
        if (request == null)
            return BadRequest("Dados inválidos");

        var resultado = _service.CriarOrcamento(request);

        if (!resultado.Sucesso)
            return BadRequest(resultado.Mensagem);

        return Ok(resultado);
    }
}