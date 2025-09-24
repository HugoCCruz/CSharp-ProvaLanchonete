using C__ProvaLanchonete.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace C__ProvaLanchonete.Menus;

internal class MenuSair : Menu
{
    public override void Executar(List<Lanche> pedido)
    {
        Console.WriteLine("Você escolheu sair");
        Thread.Sleep(2000);
        Console.Clear();
    }
}
