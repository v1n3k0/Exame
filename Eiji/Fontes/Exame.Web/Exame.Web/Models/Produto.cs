using Exame.Dominio.Entities.Base;
using Exame.Dominio.Enum;
using Exame.Web.Models;
using System.Collections.Generic;

namespace Exame.Web
{
    public class Produto : EntityBase
    {
        public string Descricao { get; set; }
        public EnumStatus Status { get; set; }
        public virtual List<Cosif> Cosifs { get; set; }
    }
}