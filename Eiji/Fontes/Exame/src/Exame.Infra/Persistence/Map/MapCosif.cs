using Exame.Dominio.Entities;
using Exame.Infra.Persistence.Map.Base;

namespace Exame.Infra.Persistence.Map
{
    class MapCosif : MapBase<Cosif>
    {
        public MapCosif()
        {
            ToTable("PRODUTO_COSIF");

            Property(x => x.Codigo).HasColumnName("COD_COSIF");
            Property(p => p.Classificacao).HasColumnName("COD_CLASSIFICACAO");
            Property(p => p.Status).HasColumnName("STA_STATUS");
            
            HasRequired(p => p.Produto).WithMany().Map(m => m.MapKey("COD_PRODUTO"));
        }
    }
}
