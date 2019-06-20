using Exame.Dominio.Entities.Base;
using Exame.Dominio.Enum;
using System.Collections.Generic;

namespace Exame.Web.Models
{
    public class Cosif : EntityBase
    {
        public EnumClassificacaoConta Classificacao { get; set; }
        public EnumStatus Status { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual List<Movimento> Movimentos { get; set; }
    }
}