using C__ProvaLanchonete.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__ProvaLanchonete.Modelos;

internal class Pedido 
{

    public void AdicionarAoPedido(List<Lanche> lanchesDisponiveis, List<Lanche> pedido, string resposta)
    {

        var item = lanchesDisponiveis.FirstOrDefault(p => p.Nome!.Equals(resposta, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                pedido.Add(item);
                Console.WriteLine("Lanche adiconado ao pedido com sucesso!");
            }
            else
            {
                Console.WriteLine("Lanche não encontrado");
            }
        
    }
    public void RemoverPedido(List<Lanche> pedido, string resposta)
    {
        var item = pedido.FirstOrDefault(p => p.Nome!.Equals(resposta, StringComparison.OrdinalIgnoreCase));
        if (pedido.Count > 0)
        {
            if (item != null)
            {
                pedido.Remove(item);
                Console.WriteLine("Lanche removido do pedido com sucesso!");
            }
            else
            {
                Console.WriteLine("Lanche não encontrado");
            }
        }
        
    }
    public void ExibirPedido(List<Lanche> pedido)
    {
        if (pedido.Count == 0)
        {
            Console.WriteLine("\nPedido Vazio");
        }
        else {
            Console.WriteLine("\nPedido atual:");
            foreach(var lanche in pedido)
            {
                Console.WriteLine($"{lanche.Nome}");
            }
        }
    }
    public double ExibirTotal(List<Lanche> pedido)
    {
        double total = 0;
        foreach(var item in pedido)
        {
                total = total + item.Valor;
        }
        Console.WriteLine($"total do pedido; {total}");

        double totalComServico = total + (total * 0.07);
        return totalComServico;
            }
}
