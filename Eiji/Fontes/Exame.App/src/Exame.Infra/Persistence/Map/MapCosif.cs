using Exame.Dominio.Entities;
using Exame.Infra.Persistence.Map.Base;

namespace Exame.Infra.Persistence.Map
{
    class MapCosif : MapBase<Cosif>
    {
        public MapCosif()
        {
            ToTable("PRODUTO_COSIF");

            Property(p => p.Codigo).IsRequired().HasColumnName("COD_COSIF");
            Property(p => p.CodigoProduto).IsRequired().HasColumnName("COD_PRODUTO");
            Property(p => p.Classificacao).HasColumnName("COD_CLASSIFICACAO");
            Property(p => p.Status).HasColumnName("STA_STATUS");

            HasRequired(c => c.Produto).WithMany(p => p.Cosifs).HasForeignKey(c => c.CodigoProduto);
        }
    }
}
