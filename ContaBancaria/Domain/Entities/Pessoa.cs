using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContaBancaria.Domain.Entities
{
    public abstract class Pessoa
    {
        public string Nome { get; private set; }
        public int CodPessoa { get; set; }
        public string Cep { get; private set; }

        protected string mensagemDocumentoInvalido = "Número de documento inválido";

        protected Pessoa(string nome, string cep, string numeroDocumento)
        {
            this.Nome = nome;
            this.Cep = cep;

            this.ValidarDocumento(numeroDocumento);
        }

        protected abstract void ValidarDocumento(string numeroDocumento);
    }
}