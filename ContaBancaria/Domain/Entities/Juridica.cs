using System;

namespace ContaBancaria.Domain.Entities
{
    public class Juridica : Pessoa
    {
        public Juridica(string nome, string cep, string cnpj)
        : base(nome, cep, cnpj) { }

        public string? NomeFantasia { get; set; }
        public string? InscricaoEstadual { get; set; }

        protected override void ValidarDocumento(string numeroDocumento)
        {
            if (numeroDocumento.Length != 14)
            {
                throw new ArgumentException(this.mensagemDocumentoInvalido);
            }
        }
    }
}