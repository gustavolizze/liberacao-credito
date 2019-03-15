using System;

namespace Core.Creditos
{
    public class CreditoDireto : Credito
    {
        public CreditoDireto(double valor, int parcelas, DateTime vencimento) : base(valor, parcelas, vencimento)
        {
        }

        public override double Taxa => 2;

        public override string Tipo => "Crédito Direto";
    }
}
