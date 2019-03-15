using System;

namespace Core.Creditos
{
    public abstract class Credito
    {
        public readonly double Valor = 0;
        public readonly int Parcelas = 0;
        public readonly DateTime Vencimento;

        public abstract double Taxa { get; }
        public abstract string Tipo { get; }

        public DateTime Final
        {
            get
            {
                return this.Vencimento.AddMonths(this.Parcelas);
            }
        }
        public int MesesTotalParaPagamento
        {
            get
            {
                var dataAtual = DateTime.Now;
                return Math.Abs((dataAtual.Month - this.Final.Month) + 12 * (dataAtual.Year - this.Final.Year));
            }
        }
        public double Total
        {
            get
            {
                return this.Valor * Math.Pow((1 + (this.Taxa / 100)), this.MesesTotalParaPagamento);
            }
        }
        public double Juros
        {
            get
            {
                return this.Total - this.Valor;
            }
        }

        public Credito(double valor, int parcelas, DateTime vencimento)
        {
            this.Valor = valor;
            this.Parcelas = parcelas;
            this.Vencimento = vencimento;
        }

        public bool ValorMaximoFoiUltrapassado()
        {
            return this.Valor > 1000000;
        }

        public bool ParcelasEstaoDentroDoLimite()
        {
            return (this.Parcelas <= 72 && this.Parcelas >= 5);
        }

        public bool VencimentoEstaDentroDoLimite()
        {
            return (this.Vencimento >= DateTime.Now.AddDays(15)) &&
                (this.Vencimento <= DateTime.Now.AddDays(40));
        }

        public virtual bool CreditoFoiAprovado()
        {
            return (this.ValorMaximoFoiUltrapassado() == false &&
                this.ParcelasEstaoDentroDoLimite() && this.VencimentoEstaDentroDoLimite());
        }
    }
}
