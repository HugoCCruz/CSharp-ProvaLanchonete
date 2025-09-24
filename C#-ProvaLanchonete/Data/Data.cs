using Microsoft.Data.Sqlite;

namespace C__ProvaLanchonete.Data;

internal class Data
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
                   CREATE TABLE IF NOT EXISTS Lanchonete (
                   id INTEGER PRIMARY KEY AUTOINCREMENT,
                   Nome TEXT NOT NULL UNIQUE,
                   Valor DOUBLE NOT NULL,
                   Descricao TEXT NOT NULL
                   );
                    ";
        
            command.ExecuteNonQuery();
        }
    }
    public static void InserirLanche(string nome, double valor, string descricao)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            var command = connection.CreateCommand();
            command.CommandText = @"ISERT INTO Lanches (Nome, Valor, Descricao) VALUES (@Nome, @Valor, @Descricao)";

            command.Parameters.AddWithValue("@Nome", nome);
            command.Parameters.AddWithValue("@Valor", valor);
            command.Parameters.AddWithValue("@descricao", descricao);
        }
    }
   public static void DeletarLanche()
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            var command = connection.CreateCommand();
            command.CommandText = @"";
        }
    }
}
