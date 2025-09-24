using C__ProvaLanchonete.Modelos;

namespace C__ProvaLanchonete.Menus;

internal class MenuFinalizarPedido : Menu
{
    Pedido pedidoFeito = new Pedido();
    public override void Executar(SortedSet<Lanche> conjuntoLanches, List<Lanche> pedido)
    {

        base.Executar(conjuntoLanches, pedido);
        ConcatenarTitulo("Finalizar Pedido");

        Console.WriteLine("Resumo do pedido:");
        Console.WriteLine("-----------------");
        pedidoFeito.ExibirPedido(pedido);
        pedidoFeito.ExibirTotal(pedido);
        Console.WriteLine("-----------------");
        Console.WriteLine("Qual será a fornma de pagaemnto\n1 - Débito\n2 - Crédito\n3 - Dinheiro");
        string escolha = Console.ReadLine()!;
        switch (escolha)
        {
            case "1":
                pedidoFeito.ExibirTotal(pedido);
                Console.WriteLine($"Forma de pagamento: Cartão de Débito");
                break;
            case "2":
                pedidoFeito.ExibirTotal(pedido);
                Console.WriteLine($"Forma de pagamento: Cartão de crédito");
                break;
            case "3":
                pedidoFeito.ExibirTotal(pedido);
                Console.WriteLine($"Forma de pagamento: Dinheiro");
                break;
            default:
                Console.WriteLine("Opção inválida");
                break;
        }
        Console.WriteLine("\nAguardando pagamento");
        Thread.Sleep(5000);
        Console.WriteLine("Pagamento Realizado!");
        Thread.Sleep(2000);

        Console.Clear();
        Console.WriteLine("\n Agradecemos a prefrência\nVolte sempre");
        Thread.Sleep(3000);
        Environment.Exit(0);
    }
}
