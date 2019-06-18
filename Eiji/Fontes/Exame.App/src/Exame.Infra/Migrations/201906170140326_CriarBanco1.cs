namespace Exame.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBanco1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MOVIMENTO_MANUAL", "COD_COSIF", "dbo.PRODUTO_COSIF");
            DropForeignKey("dbo.PRODUTO_COSIF", "COD_PRODUTO", "dbo.PRODUTO");
            AddColumn("dbo.PRODUTO_COSIF", "Produto_Codigo", c => c.Guid());
            AddColumn("dbo.MOVIMENTO_MANUAL", "Cosif_Codigo1", c => c.Guid());
            CreateIndex("dbo.PRODUTO_COSIF", "Produto_Codigo");
            CreateIndex("dbo.MOVIMENTO_MANUAL", "Cosif_Codigo1");
            AddForeignKey("dbo.MOVIMENTO_MANUAL", "Cosif_Codigo1", "dbo.PRODUTO_COSIF", "COD_COSIF");
            AddForeignKey("dbo.PRODUTO_COSIF", "Produto_Codigo", "dbo.PRODUTO", "COD_PRODUTO");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PRODUTO_COSIF", "Produto_Codigo", "dbo.PRODUTO");
            DropForeignKey("dbo.MOVIMENTO_MANUAL", "Cosif_Codigo1", "dbo.PRODUTO_COSIF");
            DropIndex("dbo.MOVIMENTO_MANUAL", new[] { "Cosif_Codigo1" });
            DropIndex("dbo.PRODUTO_COSIF", new[] { "Produto_Codigo" });
            DropColumn("dbo.MOVIMENTO_MANUAL", "Cosif_Codigo1");
            DropColumn("dbo.PRODUTO_COSIF", "Produto_Codigo");
            AddForeignKey("dbo.PRODUTO_COSIF", "COD_PRODUTO", "dbo.PRODUTO", "COD_PRODUTO", cascadeDelete: true);
            AddForeignKey("dbo.MOVIMENTO_MANUAL", "COD_COSIF", "dbo.PRODUTO_COSIF", "COD_COSIF", cascadeDelete: true);
        }
    }
}
