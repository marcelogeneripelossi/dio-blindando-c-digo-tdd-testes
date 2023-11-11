// See https://aka.ms/new-console-template for more information
using Projeto;
using System.Linq.Expressions;

internal class Program
{
    static CalculadoraGerenciador gerenciadorCalculadora = new CalculadoraGerenciador();
    static IDictionary<OperaçãoEnum, ICalculadora>? tiposDeCálculo = null;

    private static void Main(string[] args)
    {
        tiposDeCálculo = gerenciadorCalculadora.TiposDeCálculo();

        byte opcao = 0;
        bool exibe = true;

        try
        {
            while (exibe)
            {
                Console.WriteLine("Opções de Cálculo:\n");
                OpçõesDoMenu(tiposDeCálculo);


                // -------
                Console.WriteLine();
                Console.Write("Escolha a Opção para executar: ");
                byte.TryParse(Console.ReadLine(), out opcao);


                // Opção Exibir Histórico
                if (opcao == gerenciadorCalculadora.tiposDeCálculo.Count + 1)
                {
                    foreach (var historico in gerenciadorCalculadora.Histórico())
                    {
                        Console.WriteLine(historico.ToString());
                    }
                    goto PausaMenu;
                }


                // Não existe Opção de Cálculo
                if (!gerenciadorCalculadora.tiposDeCálculo.ContainsKey((OperaçãoEnum)opcao))
                    throw new Exception("Saindo da Calculadora.");


                // -------
                int número1;
                int número2;

                DigitarNúmeros(out número1, out número2);

                EfetuarExibirCálculo(opcao, número1, número2);


            // -------
            PausaMenu:
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Pressione qualquer tecla para continuar.");
                Console.ReadKey();
                Console.Clear();

            }

        }
        catch (DivideByZeroException)
        {
            Console.WriteLine();
            Console.WriteLine("Não é possível dividir por Zero.");
        }
        catch (Exception excecao)
        {
            Console.WriteLine();
            Console.WriteLine(excecao.Message);
        }
        finally
        {
            Console.WriteLine("Sistema encerrado.");
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
            Environment.Exit(0);
        }


    }

    private static void DigitarNúmeros(out int número1, out int número2)
    {
        Console.Write("Digite o 1º número: ");
        if (!int.TryParse(Console.ReadLine(), out número1))
            throw new Exception("Número inválido.");

        Console.Write("Digite o 2º número: ");
        if (!int.TryParse(Console.ReadLine(), out número2))
            throw new Exception("Número inválido.");
    }

    private static void EfetuarExibirCálculo(byte opção, int número1, int número2)
    {
        int cálculo = EfetuarCálculo(
                        operação: (OperaçãoEnum)opção,
                        número1: número1,
                        número2: número2
                      );

        Console.Write($"{(OperaçãoEnum)opção} {número1} e {número2} é igual a ");
        Console.Write(cálculo);
        Console.WriteLine();
    }

    private static void OpçõesDoMenu(IDictionary<OperaçãoEnum, ICalculadora>? tiposDeCálculo)
    {
        foreach (var tipoDeCálculo in tiposDeCálculo)
        {
            Console.WriteLine($"{(byte)tipoDeCálculo.Key} - {tipoDeCálculo.Key}");
        }
        Console.WriteLine($"{gerenciadorCalculadora.tiposDeCálculo.Count + 1} - histórico");
        Console.WriteLine("ENTER - sair");
    }

    private static int EfetuarCálculo(OperaçãoEnum operação, int número1, int número2)
    {
        return gerenciadorCalculadora.tiposDeCálculo[operação]
                .Cálculo(
                    primeiroNúmero: número1,
                    segundoNúmero: número2
                );
    }
}