using C__ProvaLanchonete.Data;
using C__ProvaLanchonete.Modelos;
using System.Runtime.CompilerServices;

namespace C__ProvaLanchonete.Menus;

internal class MenuAdicionarLanche : Menu
{
    public override void Executar(List<Lanche> pedido)
    {
        base.Executar(pedido);
        ConcatenarTitulo("Registro de lanches");
        List<Lanche> lanchesDisponiveis = DataLanches.ListarLanches();

        while (true) 
        {
            Console.WriteLine("1 - Adicionar Lanhce\n2 - Remover Lanche\n0 - Parar");
            string escolha = Console.ReadLine()!;

            if (escolha == "0")
            {
                Console.WriteLine("Você escolheu sair!");
                break;
            }
            else if (escolha == "1")
            {
                    while (true)
                    {
                        Console.WriteLine("\nDigite o nome do lanche a ser adicionado: ");
                        string nomeLanche = Console.ReadLine()!;
                        Console.WriteLine("Digite o valor do lanche: ");
                        double valorLanche = double.Parse(Console.ReadLine()!);
                        Console.WriteLine("Digite a descrição do lanche: ");
                        string descricaoLanche = Console.ReadLine()!;
                        Lanche novoLanche = new Lanche(nomeLanche, valorLanche, descricaoLanche);

                        Console.WriteLine($"O lanche está correto?\nNome: {nomeLanche}\nValor: {valorLanche}\nDescrição: {descricaoLanche}\nSim ou não?");
                        string entrada = Console.ReadLine()!;
                        string correto = entrada.Replace(" ", "").ToLowerInvariant();
                        if (correto == "sim")
                        {
                            DataLanches.InserirLanche(novoLanche);
                            break;
                        }
                    }
            }
            else if (escolha == "2")
            {
                while (true)
                {
                    foreach (var lanche in lanchesDisponiveis)
                    {
                        Console.WriteLine($"- {lanche.Nome} | {lanche.Valor} - {lanche.Descricao}");
                    }
                    Console.WriteLine("\nDigite o nome do lanche a ser removido: ");
                    string nomelanche = Console.ReadLine()!;
                    Console.WriteLine($"Tem certeza que deseja excluir o lanche: {nomelanche}?\nSim ou não ");
                    string entrada = Console.ReadLine()!;
                    string correto = entrada.Replace(" ", "").ToLowerInvariant();
                        if (correto == "sim")
                        {
                            DataLanches.DeletarLanche(nomelanche);
                            break;
                        }

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
