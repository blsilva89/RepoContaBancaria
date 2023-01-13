using System;
using System.Collections.Generic;

namespace ContaBancaria.Infra.Entities
{
    public partial class TbSaque
    {
        public TbSaque()
        {
            TbMovimentos = new HashSet<TbMovimento>();
        }

        public string CodSaque { get; set; } = null!;
        public string CodCaixa { get; set; } = null!;

        public virtual ICollection<TbMovimento> TbMovimentos { get; set; }
    }
}
