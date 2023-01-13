using System;

namespace ContaBancaria.Domain.Entities
{
    public class Conta
    {
        public Conta(int codigo, Pessoa titular, Agencia agencia)
        {
            this.Codigo = codigo;
            this.Titular = titular;
            this.Agencia = agencia;
        }

        public int Codigo { get; set; }
        public DateTime DataAbertura { get; set; }
        public decimal Saldo { get; set; }
        public Pessoa Titular { get; set; }
        public Agencia Agencia { get; set; }
    }
}