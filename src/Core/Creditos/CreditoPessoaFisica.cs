using System;

namespace Core.Creditos
{
    public class CreditoPessoaFisica : Credito
    {
        public CreditoPessoaFisica(double valor, int parcelas, DateTime vencimento) : base(valor, parcelas, vencimento)
        {
        }

        public override double Taxa => 3;

        public override string Tipo => "Crédito Pessoa Fisica";
    }
}
