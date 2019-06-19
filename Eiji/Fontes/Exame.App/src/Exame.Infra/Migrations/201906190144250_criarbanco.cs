namespace Exame.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criarbanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PRODUTO_COSIF",
                c => new
                    {
                        COD_COSIF = c.Guid(nullable: false, identity: true),
                        COD_CLASSIFICACAO = c.Int(nullable: false),
                        STA_STATUS = c.Int(nullable: false),
                        COD_PRODUTO = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.COD_COSIF)
                .ForeignKey("dbo.PRODUTO", t => t.COD_PRODUTO, cascadeDelete: true)
                .Index(t => t.COD_PRODUTO);
            
            CreateTable(
                "dbo.MOVIMENTO_MANUAL",
                c => new
                    {
                        COD_MOVIMENTO_MANUAL = c.Guid(nullable: false, identity: true),
                        DAT_MES = c.Byte(nullable: false),
                        DAT_ANO = c.Short(nullable: false),
                        NUM_LANCAMENTO = c.Int(nullable: false),
                        DES_DESCRICAO = c.String(nullable: false, maxLength: 50, unicode: false),
                        DAT_MOVIMENTO = c.DateTime(nullable: false),
                        COD_USUARIO = c.String(nullable: false, maxLength: 15, unicode: false),
                        VAL_VALOR = c.Int(nullable: false),
                        COD_COSIF = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.COD_MOVIMENTO_MANUAL)
                .ForeignKey("dbo.PRODUTO_COSIF", t => t.COD_COSIF, cascadeDelete: true)
                .Index(t => t.COD_COSIF);
            
            CreateTable(
                "dbo.PRODUTO",
                c => new
                    {
                        COD_PRODUTO = c.Guid(nullable: false, identity: true),
                        DES_PRODUTO = c.String(maxLength: 30, unicode: false),
                        STA_STATUS = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.COD_PRODUTO);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PRODUTO_COSIF", "COD_PRODUTO", "dbo.PRODUTO");
            DropForeignKey("dbo.MOVIMENTO_MANUAL", "COD_COSIF", "dbo.PRODUTO_COSIF");
            DropIndex("dbo.MOVIMENTO_MANUAL", new[] { "COD_COSIF" });
            DropIndex("dbo.PRODUTO_COSIF", new[] { "COD_PRODUTO" });
            DropTable("dbo.PRODUTO");
            DropTable("dbo.MOVIMENTO_MANUAL");
            DropTable("dbo.PRODUTO_COSIF");
        }
    }
}
