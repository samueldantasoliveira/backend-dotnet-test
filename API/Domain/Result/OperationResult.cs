namespace Domain.Result;

public class OperationResult
{
    public bool Sucesso { get; set; }
    public string Mensagem { get; set; }
    public decimal? Valor { get; set; }

    public static OperationResult Ok(string mensagem, decimal? valor = null)
        => new OperationResult { Sucesso = true, Mensagem = mensagem, Valor = valor };

    public static OperationResult Erro(string mensagem)
        => new OperationResult { Sucesso = false, Mensagem = mensagem };
}