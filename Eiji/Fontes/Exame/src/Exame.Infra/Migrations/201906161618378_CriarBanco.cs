namespace Exame.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBanco : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PRODUTO_COSIF", name: "Produto_Codigo", newName: "COD_PRODUTO");
            RenameColumn(table: "dbo.MOVIMENTO_MANUAL", name: "Cosif_Codigo", newName: "COD_COSIF");
            RenameIndex(table: "dbo.PRODUTO_COSIF", name: "IX_Produto_Codigo", newName: "IX_COD_PRODUTO");
            RenameIndex(table: "dbo.MOVIMENTO_MANUAL", name: "IX_Cosif_Codigo", newName: "IX_COD_COSIF");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.MOVIMENTO_MANUAL", name: "IX_COD_COSIF", newName: "IX_Cosif_Codigo");
            RenameIndex(table: "dbo.PRODUTO_COSIF", name: "IX_COD_PRODUTO", newName: "IX_Produto_Codigo");
            RenameColumn(table: "dbo.MOVIMENTO_MANUAL", name: "COD_COSIF", newName: "Cosif_Codigo");
            RenameColumn(table: "dbo.PRODUTO_COSIF", name: "COD_PRODUTO", newName: "Produto_Codigo");
        }
    }
}
