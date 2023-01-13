using System;
using System.Collections.Generic;

namespace ContaBancaria.Infra.Entities
{
    public partial class TbPessoaJuridica
    {
        public int CodPessoa { get; set; }
        public string Cnpj { get; set; } = null!;
        /// <summary>
        /// Inscrição estadual
        /// </summary>
        public string? Ie { get; set; }
        public string NomeFantasia { get; set; } = null!;

        public virtual TbPessoa CodPessoaNavigation { get; set; } = null!;
    }
}
