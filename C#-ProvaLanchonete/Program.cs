using C__ProvaLanchonete.Modelos;
using C__ProvaLanchonete.Menus;

SortedSet<Lanche> conjuntoLanches = new SortedSet<Lanche>();
Lanche lancheExemplo = new Lanche("X-burger", 20.50, "Pão, carne e queijo");
Lanche lancheExemplo2 = new Lanche("Hamburger", 18, "Pão e carne ");

conjuntoLanches.Add(lancheExemplo);
conjuntoLanches.Add(lancheExemplo2);

List<Lanche> pedido = new List<Lanche>();

Dictionary<int, Menu> opcoes = new Dictionary<int, Menu>();
opcoes.Add(1, new MenuAdicionarLanche());
opcoes.Add(2, new MenuFazerPedido());
opcoes.Add(3, new MenuFinalizarPedido());
opcoes.Add(0, new MenuSair());

void ExibirLogo()
{
    Console.WriteLine(@"█░░ ▄▀█ █▄░█ █▀▀ █░█ █▀█ █▄░█ █▀▀ ▀█▀ █▀▀   ░░█ █░█ █▀█ █ ▀█▀ █ █▀
█▄▄ █▀█ █░▀█ █▄▄ █▀█ █▄█ █░▀█ ██▄ ░█░ ██▄   █▄█ █▄█ █▀▄ █ ░█░ █ ▄█");
}
  void Menu()
{
    ExibirLogo();
    Console.WriteLine("------------------------");
    Console.WriteLine("1 - Adicionar Lanche");
    Console.WriteLine("2 - Realizar pedido");
    Console.WriteLine("3 - Carrinho");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("------------------------");

    Console.WriteLine("\nSelecione a opção desejada: ");
    int escolha = int.Parse(Console.ReadLine()!);

    if (opcoes.ContainsKey(escolha))
    {
        Menu menu = opcoes[escolha];
        menu.Executar(conjuntoLanches, pedido);
        if (escolha != 0) Menu();
    }
    else
    {
        Console.WriteLine("Você escolheu uma opção inválida");
    }
}


Menu();