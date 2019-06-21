﻿using Exame.Web.Arguments.Base;
using Exame.Web.Arguments.Cosif;
using System;

namespace Exame.Web.Arguments.Movimento
{
    public class MovimentoResponse : ResponseBase
    {
        public byte Mes { get; set; }
        public short Ano { get; set; }
        public int NumeroLancamento { get; set; }
        public string Descricao { get; set; }
        public DateTime DataMovimento { get; set; }
        public string Usuario { get; set; }
        public int Valor { get; set; }
        public Guid CodigoProduto { get; set; }
        public Guid CodigoCosif { get; set; }

        public static explicit operator MovimentoResponse(Models.Movimento entidade)
        {
            return new MovimentoResponse()
            {
                Mes = entidade.Mes,
                Ano = entidade.Ano,
                NumeroLancamento = entidade.NumeroLancamento,
                Descricao = entidade.Descricao,
                DataMovimento = entidade.DataMovimento,
                Usuario = entidade.Usuario,
                Valor = entidade.Valor,
                CodigoProduto = entidade.CodigoProduto,
                CodigoCosif = entidade.CodigoCosif
            };
        }
    }
}
