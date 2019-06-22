using Exame.Web.Arguments.Movimento;
using Exame.Web.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Exame.Web.Models
{
    public class Movimento : EntityBase
    {
        [Range(1, 12, ErrorMessage = "Valor entre 1 e 12")]
        [Display(Name = "Mês")]
        public byte Mes { get; set; }

        [Range(1, 10000, ErrorMessage = "Valor entre 1 e 10000")]
        [Display(Name = "Ano")]
        public short Ano { get; set; }

        [Display(Name = "Numero de Lancamento")]
        public int NumeroLancamento { get; set; }

        [Required(ErrorMessage = "Descrição Obrigadorio")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Data do Movimento")]
        public DateTime DataMovimento { get; set; }

        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Valor Obrigadorio")]
        [Display(Name = "Valor")]
        public int Valor { get; set; }

        [Required(ErrorMessage = "Cosif Obrigadorio")]
        [Display(Name = "Cosif")]
        public Guid CodigoCosif { get; set; }

        [Required(ErrorMessage = "Produto Obrigadorio")]
        [Display(Name = "Produto")]
        public Guid CodigoProduto { get; set; }

        public static explicit operator Movimento(MovimentoResponse entidade)
        {
            return new Movimento()
            {
                Mes = entidade.Mes,
                Ano = entidade.Ano,
                NumeroLancamento = entidade.NumeroLancamento,
                Descricao = entidade.Descricao,
                DataMovimento = entidade.DataMovimento,
                Usuario = entidade.Usuario,
                Valor = entidade.Valor,
                CodigoCosif = entidade.CodigoCosif,
                CodigoProduto = entidade.CodigoProduto
            };
        }
    }
}
