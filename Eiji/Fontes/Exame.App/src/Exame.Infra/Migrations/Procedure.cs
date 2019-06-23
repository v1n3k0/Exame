using System;
using System.Data.Entity.Migrations;
using System.Text;

namespace Exame.Infra.Migrations
{
    class Procedure : DbMigration
    {
        public override void Up()
        {
            StringBuilder storedProcedureCode = new StringBuilder();

            storedProcedureCode.Append("CREATE PROCEDURE ListarMovimentoProduto AS" + Environment.NewLine);
            storedProcedureCode.Append("SELECT" + Environment.NewLine);
            storedProcedureCode.Append("mm.DAT_MES as Mes," + Environment.NewLine);
            storedProcedureCode.Append("mm.COD_PRODUTO as CodigoProduto," + Environment.NewLine);
            storedProcedureCode.Append("p.DES_PRODUTO as DescricaoProduto," + Environment.NewLine);
            storedProcedureCode.Append("mm.NUM_LANCAMENTO as NumeroLancamento," + Environment.NewLine);
            storedProcedureCode.Append("mm.DES_DESCRICAO as DescricaoMovimento," + Environment.NewLine);
            storedProcedureCode.Append("mm.VAL_VALOR as Valor" + Environment.NewLine);
            storedProcedureCode.Append("FROM MOVIMENTO_MANUAL mm" + Environment.NewLine);
            storedProcedureCode.Append("INNER JOIN PRODUTO p ON mm.COD_PRODUTO = p.COD_PRODUTO" + Environment.NewLine);
            storedProcedureCode.Append("ORDER BY mm.DAT_MES, mm.DAT_ANO, mm.NUM_LANCAMENTO" + Environment.NewLine);

            this.Sql(storedProcedureCode.ToString());
        }

        public override void Down()
        {
            this.Sql("DROP PROCEDURE ListarMovimentoProduto ");
        }
    }
}
