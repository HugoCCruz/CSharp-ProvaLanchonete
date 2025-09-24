using C__ProvaLanchonete.Modelos;

namespace C__ProvaLanchonete.Menus;

internal class Menu
{
    public virtual void Executar(SortedSet<Lanche> conjuntoLanches, List<Lanche> pedido)
    {
        Console.Clear();
    }
    public void ConcatenarTitulo(string titulo)
    {
        int quantiaElementos = titulo.Length;
        String elementos = String.Empty.PadLeft(quantiaElementos, '-');
        Console.WriteLine(elementos);
        Console.WriteLine(titulo);
        Console.WriteLine(elementos + "\n");
    }

   
}
