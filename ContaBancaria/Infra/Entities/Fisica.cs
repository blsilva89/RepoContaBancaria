using System;

namespace ContaBancaria.Infra.Entities
{
    public class Fisica : Pessoa
    {
        public DateTime DataNascimento { get; }
        public Fisica(string nome, string cpf, DateTime dataNascimento) : base(nome, cpf)
        {
            this.DataNascimento = dataNascimento;
        }


        protected override void ValidarDocumento()
        {

            if (this.NumeroDocumento.Length != 11)
            {
                throw new ArgumentException(this.mensagemDocumentoInvalido);
            }
        }
    }
}
