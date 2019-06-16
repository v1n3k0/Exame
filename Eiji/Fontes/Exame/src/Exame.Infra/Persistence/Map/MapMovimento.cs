using Exame.Dominio.Entities;
using Exame.Infra.Persistence.Map.Base;

namespace Exame.Infra.Persistence.Map
{
    public class MapMovimento : MapBase<Movimento>
    {
        public MapMovimento()
        {
            ToTable("MOVIMENTO_MANUAL");

            Property(x => x.Codigo).HasColumnName("COD_MOVIMENTO_MANUAL");
            Property(p => p.Mes).IsRequired().HasColumnName("DAT_MES");
            Property(p => p.Ano).IsRequired().HasColumnName("DAT_ANO");
            Property(p => p.NumeroLancamento).IsRequired().HasColumnName("NUM_LANCAMENTO");
            Property(p => p.Valor).IsRequired().HasColumnName("VAL_VALOR");
            Property(p => p.Descricao).HasMaxLength(50).IsRequired().HasColumnName("DES_DESCRICAO");
            Property(p => p.DataMovimento).IsRequired().HasColumnName("DAT_MOVIMENTO");
            Property(p => p.Usuario).HasMaxLength(15).IsRequired().HasColumnName("COD_USUARIO");

            HasRequired(p => p.Cosif).WithMany().Map(m => m.MapKey("COD_COSIF"));
        }
    }
}
