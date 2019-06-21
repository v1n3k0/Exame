namespace Exame.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relacionamento : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.MOVIMENTO_MANUAL");
            AddPrimaryKey("dbo.MOVIMENTO_MANUAL", new[] { "COD_MOVIMENTO", "DAT_MES", "DAT_ANO", "NUM_LANCAMENTO", "COD_COSIF", "COD_PRODUTO" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.MOVIMENTO_MANUAL");
            AddPrimaryKey("dbo.MOVIMENTO_MANUAL", new[] { "COD_MOVIMENTO", "DAT_MES", "DAT_ANO", "NUM_LANCAMENTO", "COD_PRODUTO" });
        }
    }
}
