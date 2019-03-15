using Core.Helpers;
using System;

namespace Core
{
    class Program
    {
        static Simulacao Simulacoes
        {
            get
            {
                return new Simulacao();
            }
        }  

        static T TentarObter<T>(Func<T> funcaoQueLeATela)
        {
            try
            {
                return funcaoQueLeATela();
            }
            catch
            {
                Console.WriteLine("Você digitou um valor inválido !");
                return TentarObter(funcaoQueLeATela);
            }
        }

        static double ValorDaSimulacao()
        {
            Console.WriteLine("Digite o valor da simulação: ");
            return Convert.ToDouble(Console.ReadLine());
        }

        static int NumeroDeParcelas()
        {
            Console.WriteLine("Digite o número de parcelas: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        static DateTime Vencimento()
        {
            Console.WriteLine("Digite a data de vencimento desejada (Formato dd/MM/yyyy):");
            return DateHelper.ConvertDateString(Console.ReadLine());
        }

        static void Simulacao()
        {
            Console.WriteLine("Bem vindo a simulação de crédito");

            var valor = TentarObter(ValorDaSimulacao);
            var parcelas = TentarObter(NumeroDeParcelas);
            var vencimento = TentarObter(Vencimento);

            Console.WriteLine("Calculando opções, aguarde um momento ...");

            Console.WriteLine();
            Console.WriteLine("Segue a simulação:");
            Console.WriteLine();

            var resultado = Simulacoes.FazerSimulacao(valor, parcelas, vencimento);
            Console.WriteLine(Simulacoes.ImprimirResultados(resultado));

            Console.WriteLine();
            Console.WriteLine("Pressione alguma tecla para fazer uma simulação nova.");

            Console.ReadKey();
            Simulacao();
        }

        static void Main(string[] args)
        {
            try
            {
                Simulacao();
            }
            catch (Exception e)
            {
                Console.WriteLine("Houve um erro ao executar o programa: ");
                Console.WriteLine($"Erro: {e.Message}");
                Console.WriteLine($"Stack: {e.StackTrace}");
                Console.ReadKey();
            }
        }
    }
}
