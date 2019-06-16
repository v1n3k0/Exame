using Exame.Dominio.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Exame.Infra.Persistence.Map.Base
{
    public class MapBase <TEntidade> : EntityTypeConfiguration<TEntidade>
    where TEntidade : EntityBase
    {
        public MapBase()
        {
            HasKey(x => x.Codigo).Property(x => x.Codigo).IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
