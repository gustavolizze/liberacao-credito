using Core.Creditos;
using Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Core
{
    public class Simulacao
    {
        public IEnumerable<Credito> FazerSimulacao(double valor, int parcelas, DateTime vencimento)
        {
            var creditosDisponiveis = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
                                                    type.IsClass &&
                                                       type.IsAbstract == false &&
                                                            type.Namespace == "Core.Creditos"
                                                                && typeof(Credito).IsAssignableFrom(type));

            return creditosDisponiveis.Select(credito =>
            {
                return (Credito)Activator.CreateInstance(credito, new object[] { valor, parcelas, vencimento });
            });
        }

        public string ImprimirResultados(IEnumerable<Credito> simulacao)
        {
            return simulacao.OrderBy(credito => credito.Total)
                            .Select(credito => 
                                    Tuple.Create(credito.Tipo, $"R$ {credito.Total.ToString("#.##")}", $"R$ {credito.Juros.ToString("#.##")}", $"{(credito.CreditoFoiAprovado() ? "Sim" : "Não")}"))
                    .ToStringTable(new[] { "Tipo", "Total", "Juros", "Pode Fazer ?" }, a => a.Item1, a => a.Item2, a => a.Item3, a => a.Item4);
        }
    }
}
