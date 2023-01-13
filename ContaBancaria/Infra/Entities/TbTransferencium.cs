using System;
using System.Collections.Generic;

namespace ContaBancaria.Infra.Entities
{
    public partial class TbTransferencium
    {
        public TbTransferencium()
        {
            TbMovimentos = new HashSet<TbMovimento>();
        }

        public string CodTransferencia { get; set; } = null!;
        public int CodConta { get; set; }

        public virtual TbConta CodContaNavigation { get; set; } = null!;
        public virtual ICollection<TbMovimento> TbMovimentos { get; set; }
    }
}
