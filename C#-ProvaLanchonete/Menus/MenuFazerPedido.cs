using C__ProvaLanchonete.Modelos;
using System.Threading.Channels;

namespace C__ProvaLanchonete.Menus;

internal class MenuFazerPedido : Menu
{
    Pedido pedidoSendoFeito = new Pedido();
    public override void Executar(SortedSet<Lanche> conjuntoLanches, List<Lanche> pedido)
    {
        base.Executar(conjuntoLanches, pedido);
        ConcatenarTitulo("Realizar pedido");

        Console.WriteLine("Lanches disponíveis:");
        foreach(var lanche in conjuntoLanches)
        {
            Console.WriteLine($"- {lanche.Nome} | {lanche.Valor} - {lanche.Descricao}");
        }

        while (true)
        {
            pedidoSendoFeito.ExibirPedido(pedido);
            Console.WriteLine("\n1 - Adicionar Lanche\n2 - Remover Lanche\n0 - Parar");
            string escolha = Console.ReadLine()!;

            if (escolha == "0")
            {
                break;
            }
            else if(escolha == "1")
            {
               
                    Console.WriteLine("\nDigite o nome do lanche que deseja adicionar ao pedido?");
                    string resposta = Console.ReadLine()!;
                    pedidoSendoFeito.AdicionarAoPedido(conjuntoLanches, pedido, resposta);
            }
            else if (escolha == "2")
            {
                if (pedido.Count > 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Digite o nome do lanche que deseja remover do pedido?");
                    string resposta = Console.ReadLine()!;
                    pedidoSendoFeito.RemoverPedido(pedido, resposta);
                }
                else
                {
                    Console.WriteLine("Pedido Vazio, não é possivel remover itens.");
                }
            }
            else
            {
                Console.WriteLine("Opção Inválida!");
            }
        }
        Console.WriteLine("\nRetornando ao menu");
        Thread.Sleep(1000);
        Console.Clear();
    }

}
