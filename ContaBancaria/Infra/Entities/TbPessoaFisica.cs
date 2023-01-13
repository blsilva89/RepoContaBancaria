using System;
using System.Collections.Generic;

namespace ContaBancaria.Infra.Entities
{
    public partial class TbPessoaFisica
    {
        public int CodPessoa { get; set; }
        public string? Rg { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Cpf { get; set; } = null!;

        public virtual TbPessoa CodPessoaNavigation { get; set; } = null!;
    }
}
