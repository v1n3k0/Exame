﻿using Exame.Dominio.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Exame.Infra.Persistence.Map
{
    public class MapMovimento : EntityTypeConfiguration<Movimento>
    {
        public MapMovimento()
        {
            ToTable("MOVIMENTO_MANUAL");

            Property(p => p.Codigo).IsRequired().HasColumnName("COD_MOVIMENTO");
            Property(p => p.Mes).IsRequired().HasColumnName("DAT_MES");
            Property(p => p.Ano).IsRequired().HasColumnName("DAT_ANO");
            Property(p => p.NumeroLancamento).IsRequired().HasColumnName("NUM_LANCAMENTO");
            Property(p => p.Valor).IsRequired().HasColumnName("VAL_VALOR");
            Property(p => p.Descricao).HasMaxLength(50).IsRequired().HasColumnName("DES_DESCRICAO");
            Property(p => p.DataMovimento).IsRequired().HasColumnName("DAT_MOVIMENTO");
            Property(p => p.Usuario).HasMaxLength(15).IsRequired().HasColumnName("COD_USUARIO");
            Property(p => p.CodigoCosif).IsRequired().HasColumnName("COD_COSIF");
            Property(p => p.CodigoProduto).IsRequired().HasColumnName("COD_PRODUTO");

            HasKey(x => new { x.Codigo, x.Mes, x.Ano, x.NumeroLancamento, x.CodigoProduto });
            HasRequired(m => m.Cosif).WithMany(c => c.Movimentos).HasForeignKey(m => m.CodigoCosif);
        }
    }
}
