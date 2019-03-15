using System;

namespace Core.Creditos
{
    public class CreditoImobiliario : Credito
    {
        public CreditoImobiliario(double valor, int parcelas, DateTime vencimento) : base(valor, parcelas, vencimento)
        {
        }

        public override double Taxa => 9;

        public override string Tipo => "Crédito Imobiliario";
    }
}
