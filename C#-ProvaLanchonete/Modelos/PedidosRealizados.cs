using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__ProvaLanchonete.Modelos;

internal class PedidosRealizados
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public double Total { get; set; }
    public string? Pagamento { get; set; }

    public PedidosRealizados( string? nome, double total, string? pagamento)
    {
        Nome = nome;
        Total = total;
        Pagamento = pagamento;
    }
}
