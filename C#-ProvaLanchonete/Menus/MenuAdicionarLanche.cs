using C__ProvaLanchonete.Modelos;
using System.Runtime.CompilerServices;

namespace C__ProvaLanchonete.Menus;

internal class MenuAdicionarLanche : Menu
{
    public override void Executar(SortedSet<Lanche> conjuntoLanches, List<Lanche> pedido)
    {
        base.Executar(conjuntoLanches, pedido);
        ConcatenarTitulo("Registro de lanches");

        while (true) 
        {
            Console.WriteLine("1 - Adicionar Lanhce\n0 - Parar");
            string escolha = Console.ReadLine()!;

            if (escolha == "0")
            {
                Console.WriteLine("Você escolheu sair!");
                break;
            }
            else if (escolha == "1")
            {
                if (conjuntoLanches.Count() < 10)
                {
        
                    while (true)
                    {
                        Console.WriteLine("\nDigite o nome do lanche a ser adicionado: ");
                        string nomeLanche = Console.ReadLine()!;
                        Console.WriteLine("Digite o valor do lanche: ");
                        double valorLanche = double.Parse(Console.ReadLine()!);
                        Console.WriteLine("Digite a descrição do lanche: ");
                        string descricaoLanche = Console.ReadLine()!;

                        Console.WriteLine($"O pedido está correto?\nNome: {nomeLanche}\nValor: {valorLanche}\nDescrição: {descricaoLanche}\nSim ou não?");
                        string entrada = Console.ReadLine()!;
                        string correto = entrada.Replace(" ", "").ToLowerInvariant();
                        if (correto == "sim")
                        {
                            conjuntoLanches.Add(new Lanche(nomeLanche, valorLanche, descricaoLanche));
                            break;
                        }
                        else if (correto == "não")
                        {

                        }
                    }
                }
                else
                {
                    Console.WriteLine("Você atingiu o limite de lanhces a ser adicionado");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida");
            }

        }
            Console.WriteLine("\nRetornando ao menu");
            Thread.Sleep(1000);
            Console.Clear();

    }
}
