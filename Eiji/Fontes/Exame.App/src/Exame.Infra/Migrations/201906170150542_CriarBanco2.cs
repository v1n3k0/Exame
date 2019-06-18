namespace Exame.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBanco2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MOVIMENTO_MANUAL", "Cosif_Codigo1", "dbo.PRODUTO_COSIF");
            DropForeignKey("dbo.PRODUTO_COSIF", "Produto_Codigo", "dbo.PRODUTO");
            DropIndex("dbo.PRODUTO_COSIF", new[] { "Produto_Codigo" });
            DropIndex("dbo.PRODUTO_COSIF", new[] { "COD_PRODUTO" });
            DropIndex("dbo.MOVIMENTO_MANUAL", new[] { "COD_COSIF" });
            DropIndex("dbo.MOVIMENTO_MANUAL", new[] { "Cosif_Codigo1" });
            DropColumn("dbo.PRODUTO_COSIF", "COD_PRODUTO");
            DropColumn("dbo.MOVIMENTO_MANUAL", "COD_COSIF");
            RenameColumn(table: "dbo.MOVIMENTO_MANUAL", name: "Cosif_Codigo1", newName: "COD_COSIF");
            RenameColumn(table: "dbo.PRODUTO_COSIF", name: "Produto_Codigo", newName: "COD_PRODUTO");
            AlterColumn("dbo.PRODUTO_COSIF", "COD_PRODUTO", c => c.Guid(nullable: false));
            AlterColumn("dbo.MOVIMENTO_MANUAL", "COD_COSIF", c => c.Guid(nullable: false));
            CreateIndex("dbo.PRODUTO_COSIF", "COD_PRODUTO");
            CreateIndex("dbo.MOVIMENTO_MANUAL", "COD_COSIF");
            AddForeignKey("dbo.MOVIMENTO_MANUAL", "COD_COSIF", "dbo.PRODUTO_COSIF", "COD_COSIF", cascadeDelete: true);
            AddForeignKey("dbo.PRODUTO_COSIF", "COD_PRODUTO", "dbo.PRODUTO", "COD_PRODUTO", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PRODUTO_COSIF", "COD_PRODUTO", "dbo.PRODUTO");
            DropForeignKey("dbo.MOVIMENTO_MANUAL", "COD_COSIF", "dbo.PRODUTO_COSIF");
            DropIndex("dbo.MOVIMENTO_MANUAL", new[] { "COD_COSIF" });
            DropIndex("dbo.PRODUTO_COSIF", new[] { "COD_PRODUTO" });
            AlterColumn("dbo.MOVIMENTO_MANUAL", "COD_COSIF", c => c.Guid());
            AlterColumn("dbo.PRODUTO_COSIF", "COD_PRODUTO", c => c.Guid());
            RenameColumn(table: "dbo.PRODUTO_COSIF", name: "COD_PRODUTO", newName: "Produto_Codigo");
            RenameColumn(table: "dbo.MOVIMENTO_MANUAL", name: "COD_COSIF", newName: "Cosif_Codigo1");
            AddColumn("dbo.MOVIMENTO_MANUAL", "COD_COSIF", c => c.Guid(nullable: false));
            AddColumn("dbo.PRODUTO_COSIF", "COD_PRODUTO", c => c.Guid(nullable: false));
            CreateIndex("dbo.MOVIMENTO_MANUAL", "Cosif_Codigo1");
            CreateIndex("dbo.MOVIMENTO_MANUAL", "COD_COSIF");
            CreateIndex("dbo.PRODUTO_COSIF", "COD_PRODUTO");
            CreateIndex("dbo.PRODUTO_COSIF", "Produto_Codigo");
            AddForeignKey("dbo.PRODUTO_COSIF", "Produto_Codigo", "dbo.PRODUTO", "COD_PRODUTO");
            AddForeignKey("dbo.MOVIMENTO_MANUAL", "Cosif_Codigo1", "dbo.PRODUTO_COSIF", "COD_COSIF");
        }
    }
}
