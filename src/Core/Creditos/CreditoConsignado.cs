using System;

namespace Core.Creditos
{
    public class CreditoConsignado : Credito
    {
        public CreditoConsignado(double valor, int parcelas, DateTime vencimento) : base(valor, parcelas, vencimento)
        {
        }

        public override double Taxa => 1;

        public override string Tipo => "Crédito Consignado";
    }
}
