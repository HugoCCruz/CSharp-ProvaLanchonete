using C__ProvaLanchonete.Modelos;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__ProvaLanchonete.Data;

internal class DataPedidos
{
    private const string connectionString = "Data Source=CSharp-ProvaLanchonete";

    public static void CriarTabela()
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
                @"
                  CREATE TABLE IF NOT EXISTS Pedidos (
                  Id INTEGER PRIMARY KEY AUTOINCREMENT,
                  Nome TEXT NOT NULL,
                  Total DOUBLE NOT NULL,
                  Pagamento STRING NOT NULL
                  );
                    ";

            command.ExecuteNonQuery();
        }
    }
    public static void InserirPedido(string nome, double total, string pagamento)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            try
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO Pedidos (Nome, Total, Pagamento) VALUES (@Nome, @Total, @Pagamento)";

                command.Parameters.AddWithValue("@Nome", nome);
                command.Parameters.AddWithValue("@Total", total);
                command.Parameters.AddWithValue("@Pagamento", pagamento);

                command.ExecuteNonQuery();
            }
            catch (SqliteException ex)
            {
                if (ex.SqliteErrorCode == 19)
                {
                    Console.WriteLine($"Erro: Não foi possível adicionar o pedido.");
                }
                else
                {
                    Console.WriteLine($"Ocorreu um erro no banco de dados: {ex.Message}");
                }
            }
        }
    }

    public static List<PedidosRealizados> ListarPedidos()
    {
        var pedidosRealizados = new List<PedidosRealizados>();
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Nome, Total, Pagamento FROM Pedidos";

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var pedido = new PedidosRealizados(reader.GetString(1), reader.GetDouble(2), reader.GetString(3));
                    pedido.Id = reader.GetInt32(0);
                    pedidosRealizados.Add(pedido);
                }
            }
        }
        return pedidosRealizados;
    }

}
