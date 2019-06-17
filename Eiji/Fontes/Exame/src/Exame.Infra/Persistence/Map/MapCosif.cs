using Exame.Dominio.Entities;
using Exame.Infra.Persistence.Map.Base;

namespace Exame.Infra.Persistence.Map
{
    class MapCosif : MapBase<Cosif>
    {
        public MapCosif()
        {
            ToTable("PRODUTO_COSIF");

            Property(p => p.Codigo).HasColumnName("COD_COSIF");
            Property(p => p.Classificacao).HasColumnName("COD_CLASSIFICACAO");
            Property(p => p.Status).HasColumnName("STA_STATUS");

            HasRequired(c => c.Produto).WithMany(p => p.Cosifs).Map(m => m.MapKey("COD_PRODUTO"));            
        }
    }
}
