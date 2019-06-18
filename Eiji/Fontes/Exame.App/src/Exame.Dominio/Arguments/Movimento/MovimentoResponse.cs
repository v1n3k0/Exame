using Exame.Dominio.Arguments.Base;
using System;

namespace Exame.Dominio.Arguments.Movimento
{
    public class MovimentoResponse: ResponseBase
    {
        public Guid Codigo { get; set; }
        public byte Mes { get; set; }
        public short Ano { get; set; }
        public int NumeroLancamento { get; set; }
        public string Descricao { get; set; }
        public string Usuario { get; set; }
        public int Valor { get; set; }

        public static explicit operator MovimentoResponse(Entities.Movimento entidade)
        {
            return new MovimentoResponse()
            {
                Codigo = entidade.Codigo,
                Mes = entidade.Mes,
                Ano = entidade.Ano,
                NumeroLancamento = entidade.NumeroLancamento,
                Descricao = entidade.Descricao,
                Usuario = entidade.Usuario,
                Valor = entidade.Valor
            };
        }
    }
}
