namespace Exame.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoverCodigoMovimento : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MOVIMENTO_MANUAL", "COD_MOVIMENTO", "dbo.PRODUTO");
            DropForeignKey("dbo.PRODUTO_COSIF", "COD_PRODUTO", "dbo.PRODUTO");
            DropIndex("dbo.MOVIMENTO_MANUAL", new[] { "COD_MOVIMENTO" });
            RenameColumn(table: "dbo.MOVIMENTO_MANUAL", name: "COD_MOVIMENTO", newName: "Produto_Codigo");
            DropPrimaryKey("dbo.MOVIMENTO_MANUAL");
            DropPrimaryKey("dbo.PRODUTO");
            AlterColumn("dbo.MOVIMENTO_MANUAL", "Produto_Codigo", c => c.Guid());
            AlterColumn("dbo.PRODUTO", "COD_PRODUTO", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.MOVIMENTO_MANUAL", new[] { "DAT_MES", "DAT_ANO", "NUM_LANCAMENTO", "COD_COSIF", "COD_PRODUTO" });
            AddPrimaryKey("dbo.PRODUTO", "COD_PRODUTO");
            CreateIndex("dbo.MOVIMENTO_MANUAL", "Produto_Codigo");
            AddForeignKey("dbo.MOVIMENTO_MANUAL", "Produto_Codigo", "dbo.PRODUTO", "COD_PRODUTO");
            AddForeignKey("dbo.PRODUTO_COSIF", "COD_PRODUTO", "dbo.PRODUTO", "COD_PRODUTO");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PRODUTO_COSIF", "COD_PRODUTO", "dbo.PRODUTO");
            DropForeignKey("dbo.MOVIMENTO_MANUAL", "Produto_Codigo", "dbo.PRODUTO");
            DropIndex("dbo.MOVIMENTO_MANUAL", new[] { "Produto_Codigo" });
            DropPrimaryKey("dbo.PRODUTO");
            DropPrimaryKey("dbo.MOVIMENTO_MANUAL");
            AlterColumn("dbo.PRODUTO", "COD_PRODUTO", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.MOVIMENTO_MANUAL", "Produto_Codigo", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.PRODUTO", "COD_PRODUTO");
            AddPrimaryKey("dbo.MOVIMENTO_MANUAL", new[] { "COD_MOVIMENTO", "DAT_MES", "DAT_ANO", "NUM_LANCAMENTO", "COD_COSIF", "COD_PRODUTO" });
            RenameColumn(table: "dbo.MOVIMENTO_MANUAL", name: "Produto_Codigo", newName: "COD_MOVIMENTO");
            CreateIndex("dbo.MOVIMENTO_MANUAL", "COD_MOVIMENTO");
            AddForeignKey("dbo.PRODUTO_COSIF", "COD_PRODUTO", "dbo.PRODUTO", "COD_PRODUTO");
            AddForeignKey("dbo.MOVIMENTO_MANUAL", "COD_MOVIMENTO", "dbo.PRODUTO", "COD_PRODUTO");
        }
    }
}
