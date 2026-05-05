using Domain.DTOs;
using Domain.Entities;
using Domain.Result;

namespace Application.Services;

public class OrcamentoService
{
    public OperationResult CriarOrcamento(CriarOrcamentoRequest request)
    {
        // 1. Validações básicas
        if (request.ClienteId <= 0)
            return OperationResult.Erro("ClienteId é obrigatório");

        if (request.VeiculoId <= 0)
            return OperationResult.Erro("VeiculoId é obrigatório");

        if (request.Itens == null || !request.Itens.Any())
            return OperationResult.Erro("Deve existir pelo menos 1 item");

        foreach (var item in request.Itens)
        {
            if (string.IsNullOrWhiteSpace(item.Descricao))
                return OperationResult.Erro("Item sem descrição");

            if (item.Quantidade <= 0)
                return OperationResult.Erro("Quantidade deve ser maior que zero");

            if (item.ValorUnitario <= 0)
                return OperationResult.Erro("Valor unitário deve ser maior que zero");
        }

        // 2. Criação da entidade
        var orcamento = new Orcamento
        {
            ClienteId = request.ClienteId,
            VeiculoId = request.VeiculoId,
            DataCriacao = DateTime.Now,
            Status = "Aberto"
        };

        // 3. Mapeia itens e calcula total
        decimal total = 0;

        foreach (var item in request.Itens)
        {
            var novoItem = new OrcamentoItem
            {
                Descricao = item.Descricao,
                Quantidade = item.Quantidade,
                ValorUnitario = item.ValorUnitario
            };

            total += novoItem.Quantidade * novoItem.ValorUnitario;
            orcamento.Itens.Add(novoItem);
        }

        orcamento.ValorTotal = total;

        // 4. Retorno
        return OperationResult.Ok("Orçamento criado com sucesso", total);
    }
}