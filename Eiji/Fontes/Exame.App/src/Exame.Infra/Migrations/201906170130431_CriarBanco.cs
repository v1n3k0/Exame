namespace Exame.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBanco : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MOVIMENTO_MANUAL", "COD_COSIF", "dbo.PRODUTO_COSIF");
            DropForeignKey("dbo.PRODUTO_COSIF", "COD_PRODUTO", "dbo.PRODUTO");
            DropIndex("dbo.PRODUTO_COSIF", new[] { "COD_PRODUTO" });
            DropIndex("dbo.MOVIMENTO_MANUAL", new[] { "COD_COSIF" });
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
            CreateIndex("dbo.MOVIMENTO_MANUAL", "COD_COSIF");
            CreateIndex("dbo.PRODUTO_COSIF", "COD_PRODUTO");
            AddForeignKey("dbo.PRODUTO_COSIF", "COD_PRODUTO", "dbo.PRODUTO", "COD_PRODUTO");
            AddForeignKey("dbo.MOVIMENTO_MANUAL", "COD_COSIF", "dbo.PRODUTO_COSIF", "COD_COSIF");
        }
    }
}
