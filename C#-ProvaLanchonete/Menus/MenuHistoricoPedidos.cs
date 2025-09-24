using C__ProvaLanchonete.Data;
using C__ProvaLanchonete.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__ProvaLanchonete.Menus;

internal class MenuHistoricoPedidos : Menu
{
    public override void Executar(List<Lanche> pedido)
    {

        base.Executar(pedido);
        ConcatenarTitulo("Histórico de pedidos");

        List<PedidosRealizados> pedidosRealizados = DataPedidos.ListarPedidos();

        foreach(var item in pedidosRealizados)
        {
            Console.WriteLine($"Id: {item.Id} | Nome: {item.Nome} | Valor: {item.Total} | Pagamento: {item.Pagamento}");
        }
    }
}
