using Exame.Dominio.Entities;
using Exame.Infra.Persistence.Map.Base;

namespace Exame.Infra.Persistence.Map
{
    public class MapProduto : MapBase<Produto>
    {
        public MapProduto()
        {
            ToTable("PRODUTO");

            Property(p => p.Codigo).HasColumnName("COD_PRODUTO");
            Property(p => p.Descricao).HasMaxLength(30).HasColumnName("DES_PRODUTO");
            Property(p => p.Status).HasColumnName("STA_STATUS");
        }
    }
}
