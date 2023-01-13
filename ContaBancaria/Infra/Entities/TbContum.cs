using System;
using System.Collections.Generic;

namespace ContaBancaria.Infra.Entities
{
    public partial class TbConta
    {
        public TbConta()
        {
            TbMovimentos = new HashSet<TbMovimento>();
            TbTransferencia = new HashSet<TbTransferencium>();
        }

        public int CodConta { get; set; }
        public decimal Saldo { get; set; }
        public DateTime DataAbertura { get; set; }
        public int CodPessoa { get; set; }
        public int CodAgencia { get; set; }

        public virtual TbAgencia CodAgenciaNavigation { get; set; } = null!;
        public virtual TbPessoa CodPessoaNavigation { get; set; } = null!;
        public virtual ICollection<TbMovimento> TbMovimentos { get; set; }
        public virtual ICollection<TbTransferencium> TbTransferencia { get; set; }
    }
}
