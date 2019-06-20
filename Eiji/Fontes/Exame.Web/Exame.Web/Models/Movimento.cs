﻿using Exame.Dominio.Entities.Base;
using System;

namespace Exame.Web.Models
{
    public class Movimento : EntityBase
    {
        public byte Mes { get; set; }
        public short Ano { get; set; }
        public int NumeroLancamento { get; set; }
        public string Descricao { get; set; }
        public DateTime DataMovimento { get; set; }
        public string Usuario { get; set; }
        public int Valor { get; set; }
        public virtual Cosif Cosif { get; set; }
    }
}