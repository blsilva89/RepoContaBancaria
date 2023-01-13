using System;
using System.Collections.Generic;

namespace ContaBancaria.Infra.Entities
{
    public partial class TbMovimento
    {
        public string CodMovimento { get; set; } = null!;
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public int CodConta { get; set; }
        public int CodTipoMovimento { get; set; }
        public string CodTransferencia { get; set; } = null!;
        public string CodSaque { get; set; } = null!;

        public virtual TbConta CodContaNavigation { get; set; } = null!;
        public virtual TbSaque CodSaqueNavigation { get; set; } = null!;
        public virtual TbTipoMovimento CodTipoMovimentoNavigation { get; set; } = null!;
        public virtual TbTransferencium CodTransferenciaNavigation { get; set; } = null!;
    }
}
