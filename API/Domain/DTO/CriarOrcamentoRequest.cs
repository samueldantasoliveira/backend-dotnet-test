namespace Domain.DTOs;

public class CriarOrcamentoRequest
{
    public int ClienteId { get; set; }
    public int VeiculoId { get; set; }
    public List<OrcamentoItemRequest> Itens { get; set; }
}