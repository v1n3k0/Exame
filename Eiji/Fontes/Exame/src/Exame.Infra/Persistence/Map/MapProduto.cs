using Exame.Dominio.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Exame.Infra.Persistence.Map
{
    public class MapProduto : EntityTypeConfiguration<Produto>
    {
        public MapProduto()
        {
            ToTable("PRODUTO");

            HasKey(x => x.Codigo).Property(x => x.Codigo).HasColumnName("COD_PRODUTO").IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Descricao).HasMaxLength(30).HasColumnName("DES_PRODUTO");
            Property(p => p.Status).HasColumnName("STA_STATUS");
        }
    }
}
