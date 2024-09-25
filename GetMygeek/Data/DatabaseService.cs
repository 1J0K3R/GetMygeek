using GetMygeek.Data.ORM;
using GetMygeek.Models;
using Npgsql;

namespace GetMygeek.Data;
public class DatabaseService : IDatabaseService
{
    private readonly string _connectionString;

    public DatabaseService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IEnumerable<Consultant>> GetAllConsultantsAsync()
    {
        var consultants = new List<Consultant>();

        // Créer une connexion à la base de données
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        // Définir la commande SQL pour récupérer toutes les colonnes de la table Consultant
        var sql = "SELECT * FROM Consultant;";

        await using var command = new NpgsqlCommand(sql, connection);
        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            // Créer un objet Consultant pour chaque ligne de résultats
            var consultant = new Consultant
            {
                IdConsultant = reader.GetInt64(0),
                Nom = reader.GetString(1),
                Tel = !reader.IsDBNull(2) ? reader.GetString(2) : null,
                Mail = !reader.IsDBNull(3) ? reader.GetString(3) : null,
                DdcUrl = !reader.IsDBNull(4) ? reader.GetString(4) : null,
                IdMission = !reader.IsDBNull(5) ? reader.GetInt64(5) : null,
                ResponsableCarriere = !reader.IsDBNull(6) ? reader.GetString(6) : null,
                Anciennete = !reader.IsDBNull(7) ? reader.GetInt32(7) : null,
                Disponibilite = !reader.IsDBNull(8) ? reader.GetString(8) : null,
                IdPrefDomain = !reader.IsDBNull(9) ? reader.GetInt64(9) : null,
                ImageUrl = !reader.IsDBNull(10) ? reader.GetString(10) : null,
                Trigramme = !reader.IsDBNull(11) ? reader.GetString(11) : null
            };

            // Ajouter l'objet consultant à la liste
            consultants.Add(consultant);
        }

        return consultants;
    }

    public async Task<IEnumerable<Consultant>> GetConsultantsResearchBar(ResearchQuery researchQuery)
    {
        var consultants = new List<Consultant>();

        // Créer une connexion à la base de données
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        // Définir la commande SQL pour récupérer toutes les colonnes de la table Consultant
        var sql = researchQuery.GenerateSQL();

        await using var command = new NpgsqlCommand(sql, connection);
        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            // Créer un objet Consultant pour chaque ligne de résultats
            var consultant = new Consultant
            {
                IdConsultant = reader.GetInt64(0),
                Nom = reader.GetString(1),
                Tel = !reader.IsDBNull(2) ? reader.GetString(2) : null,
                Mail = !reader.IsDBNull(3) ? reader.GetString(3) : null,
                DdcUrl = !reader.IsDBNull(4) ? reader.GetString(4) : null,
                IdMission = !reader.IsDBNull(5) ? reader.GetInt64(5) : null,
                ResponsableCarriere = !reader.IsDBNull(6) ? reader.GetString(6) : null,
                Anciennete = !reader.IsDBNull(7) ? reader.GetInt32(7) : null,
                Disponibilite = !reader.IsDBNull(8) ? reader.GetString(8) : null,
                IdPrefDomain = !reader.IsDBNull(9) ? reader.GetInt64(9) : null,
                ImageUrl = !reader.IsDBNull(10) ? reader.GetString(10) : null,
                Trigramme = !reader.IsDBNull(11) ? reader.GetString(11) : null
            };

            // Ajouter l'objet consultant à la liste
            consultants.Add(consultant);
        }

        return consultants;
    }
}