Use MovimentosManuais

GO
CREATE PROCEDURE ListarMovimentoProduto
AS
SELECT 
mm.DAT_MES as Mes, 
mm.DAT_ANO as Ano,
mm.COD_PRODUTO as CodigoProduto,
p.DES_PRODUTO as DescricaoProduto,
mm.NUM_LANCAMENTO as NumeroLancamento,
mm.DES_DESCRICAO as DescricaoMovimento,
mm.VAL_VALOR as Valor
FROM MOVIMENTO_MANUAL mm
INNER JOIN PRODUTO p ON mm.COD_PRODUTO = p.COD_PRODUTO
ORDER BY mm.DAT_MES, mm.DAT_ANO, mm.NUM_LANCAMENTO