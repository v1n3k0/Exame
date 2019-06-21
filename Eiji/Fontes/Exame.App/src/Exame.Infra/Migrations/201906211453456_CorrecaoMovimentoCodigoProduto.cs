namespace Exame.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrecaoMovimentoCodigoProduto : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MOVIMENTO_MANUAL", "Produto_Codigo", "dbo.PRODUTO");
            DropIndex("dbo.MOVIMENTO_MANUAL", new[] { "Produto_Codigo" });
            DropColumn("dbo.MOVIMENTO_MANUAL", "Produto_Codigo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MOVIMENTO_MANUAL", "Produto_Codigo", c => c.Guid());
            CreateIndex("dbo.MOVIMENTO_MANUAL", "Produto_Codigo");
            AddForeignKey("dbo.MOVIMENTO_MANUAL", "Produto_Codigo", "dbo.PRODUTO", "COD_PRODUTO");
        }
    }
}
