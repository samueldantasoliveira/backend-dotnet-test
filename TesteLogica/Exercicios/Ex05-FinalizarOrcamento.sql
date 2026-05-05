CREATE PROCEDURE sp_FinalizarOrcamento
    @OrcamentoId
AS
BEGIN
    -- 1. Verificar se orçamento existe
    IF NOT EXISTS(SELECT 1 FROM Orcamento WHERE id = @OrcamentoId);
    BEGIN   
        SELECT 'Orçamento não encontrado' AS Mensagem;
        return
    END

    -- 2. Verificar status
    IF EXISTS( 
        SELECT 1
        FROM Orcamento
        WHERE id = @OrcamentoId AND Status <> 'Aberto'
    )
    BEGIN
        SELECT 'Orçamento não está aberto' AS Mensagem;
        Return;
    END

    -- 3. Verificar se tem itens
    IF NOT EXISTS (
        SELECT 1 
        FROM OrcamentoItem
        WHERE OrcamentoId = @OrcamentoId
    )
    BEGIN
        SELECT 'Orçamento não possui itens' AS Mensagem;
        RETURN;
    END

    -- 4. Recalcular total
    DECLARE @Total DECIMAL(18,2);

    SELECT @Total = SUM(Quantidade * ValorUnitario)
    FROM OrcamentoItem
    WHERE OrcamentoId = @OrcamentoId;

    -- 5. Atualizar orçamento
    UPDATE Orcamento
    SET 
        ValorTotal = @Total,
        Status = 'Finalizado',
        DataFinalizacao = GETDATE()
    WHERE Id = @OrcamentoId;

    -- 6. Retorno
    SELECT 'Orçamento finalizado com sucesso' AS Mensagem;
END;