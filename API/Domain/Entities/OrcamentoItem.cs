namespace Domain.Entities;

public class OrcamentoItem
{
    public int Id { get; set; }
    public int OrcamentoId { get; set; }

    public string Descricao { get; set; }
    public int Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }

    public decimal ValorTotal => Quantidade * ValorUnitario;
}