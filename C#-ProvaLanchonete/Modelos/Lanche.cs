using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__ProvaLanchonete.Modelos;

internal class Lanche
{
    public string? Nome { get; set; }
    public double Valor { get; set; }
    public string? Descricao { get; set; }

    public Lanche(string? nome, double valor, string? descricao)
    {
        Nome = nome;
        Valor = valor;
        Descricao = descricao;
    }

}
