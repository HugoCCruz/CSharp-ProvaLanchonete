using C__ProvaLanchonete.Data;
using C__ProvaLanchonete.Modelos;

namespace C__ProvaLanchonete.Menus;

internal class MenuFinalizarPedido : Menu
{
    Pedido pedidoFeito = new Pedido();
    public override void Executar(List<Lanche> pedido)
    {

        base.Executar(pedido);
        ConcatenarTitulo("Finalizar Pedido");

        Console.WriteLine("Resumo do pedido:");
        Console.WriteLine("-----------------");
        pedidoFeito.ExibirPedido(pedido);
        double total = pedidoFeito.ExibirTotal(pedido);
        Console.WriteLine("-----------------");
        Console.WriteLine("Digite seu nome para confirmar o pedido: ");
        string nome = Console.ReadLine()!;
        Console.WriteLine("Qual será a fornma de pagaemnto\nDébito\nCrédito\nDinheiro ");
        string escolha = Console.ReadLine()!;
        string pagamento = escolha.Replace(" ", "").Replace("é", "e").ToLowerInvariant();
        switch (pagamento)
        {
            case "debito":
                pedidoFeito.ExibirTotal(pedido);
                Console.WriteLine($"Forma de pagamento: Cartão de Débito");
                break;
            case "credito":
                pedidoFeito.ExibirTotal(pedido);
                Console.WriteLine($"Forma de pagamento: Cartão de crédito");
                break;
            case "dinheiro":
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
        DataPedidos.InserirPedido(nome, total, pagamento);
        Thread.Sleep(2000);

        Console.Clear();
        Console.WriteLine("\n Agradecemos a prefrência\nVolte sempre");
        Thread.Sleep(3000);
        Environment.Exit(0);
    }
}
