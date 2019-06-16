﻿using Exame.Dominio.Arguments.Base;
using System;

namespace Exame.Dominio.Arguments.Cosif
{
    public class AdicionarCosifRequest: RequestBase
    {
        public Guid CodProduto { get; set; }
        public string Classificacao { get; set; }
    }
}
