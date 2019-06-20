using Exame.Dominio.Enum;
using System;
using System.Collections.Generic;

namespace Exame.Web.Models
{
    public class Cosif
    {
        public EnumClassificacaoConta Classificacao { get; set; }
        public EnumStatus Status { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual List<Movimento> Movimentos { get; set; }
    }
}