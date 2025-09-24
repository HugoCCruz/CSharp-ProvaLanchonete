using C__ProvaLanchonete.Modelos;
using Microsoft.Data.Sqlite;

namespace C__ProvaLanchonete.Data;

internal class DataLanches
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
                   CREATE TABLE IF NOT EXISTS Lanches (
                   id INTEGER PRIMARY KEY AUTOINCREMENT,
                   Nome TEXT NOT NULL UNIQUE,
                   Valor DOUBLE NOT NULL,
                   Descricao TEXT NOT NULL
                   );
                    ";
        
            command.ExecuteNonQuery();
        }
    }
    public static void InserirLanche(Lanche novoLanche)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            try
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO Lanches (Nome, Valor, Descricao) VALUES (@Nome, @Valor, @Descricao)";

                command.Parameters.AddWithValue("@Nome", novoLanche.Nome);
                command.Parameters.AddWithValue("@Valor", novoLanche.Valor);
                command.Parameters.AddWithValue("@Descricao", novoLanche.Descricao);

                command.ExecuteNonQuery();
                Console.WriteLine($"Lanche '{novoLanche.Nome}' adicionado com sucesso!");
            }
            catch (SqliteException ex)
            {
                if (ex.SqliteErrorCode == 19)
                {
                    Console.WriteLine($"Erro: Não foi possível adicionar o lanche. O nome '{novoLanche.Nome}' já existe.");
                }
                else
                {
                    Console.WriteLine($"Ocorreu um erro no banco de dados: {ex.Message}");
                }
            }
        }
    }
    public static void DeletarLanche(string nome)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            var checkCommand = connection.CreateCommand();
            checkCommand.CommandText = "SELECT COUNT(*) FROM Lanches WHERE Nome = @Nome";
            checkCommand.Parameters.AddWithValue("@Nome", nome);

            long count = (long)checkCommand.ExecuteScalar()!;

            if (count > 0)
            {
                var deleteCommand = connection.CreateCommand();
                deleteCommand.CommandText = "DELETE FROM Lanches WHERE Nome = @Nome";
                deleteCommand.Parameters.AddWithValue("@Nome", nome);

                deleteCommand.ExecuteNonQuery();
                Console.WriteLine($"Lanche '{nome}' deletado com sucesso!");
            }
            else
            {
                Console.WriteLine($"Erro: O lanche '{nome}' não foi encontrado.");
            }
        }
    }
    public static List<Lanche> ListarLanches()
    {
        var lanchesDisponiveis = new List<Lanche>();
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Nome, Valor, Descricao FROM Lanches";

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var lanche = new Lanche(reader.GetString(1), reader.GetDouble(2), reader.GetString(3));
                    lanche.Id = reader.GetInt32(0);
                    lanchesDisponiveis.Add(lanche);
                }
            }
        }
        return lanchesDisponiveis;
    }
    public static int ContarLanches()
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM Lanches";
            int count = (int)command.ExecuteScalar()!;

            return count;
        }
        
    }
}
