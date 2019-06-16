using Exame.Dominio.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Exame.Infra.Persistence.Map
{
    class MapCosif : EntityTypeConfiguration<Cosif>
    {
        public MapCosif()
        {
            ToTable("PRODUTO_COSIF");

            HasKey(x => x.Codigo).Property(x => x.Codigo).HasColumnName("COD_COSIF").IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Classificacao).HasColumnName("COD_CLASSIFICACAO");
            Property(p => p.Status).HasColumnName("STA_STATUS");
            
            HasRequired(p => p.Produto).WithMany().Map(m => m.MapKey("COD_PRODUTO"));
        }
    }
}
