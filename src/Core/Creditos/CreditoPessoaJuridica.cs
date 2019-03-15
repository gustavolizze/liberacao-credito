using System;

namespace Core.Creditos
{
    public class CreditoPessoaJuridica : Credito
    {
        public CreditoPessoaJuridica(double valor, int parcelas, DateTime vencimento) : base(valor, parcelas, vencimento)
        {
        }

        public override double Taxa => 5;

        public override string Tipo => "Crédito Pessoa Juridica";

        public override bool CreditoFoiAprovado()
        {
            if (this.Valor < 15000)
                return false;

            return base.CreditoFoiAprovado();
        }
    }
}
