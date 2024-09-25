using GetMygeek.Data.ORM;

namespace GetMygeek.Data;
public interface IDatabaseService
{
    /// <summary>
    /// Fonction qui récupère tous les enregistrements de la table "consultant"
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Consultant>> GetAllConsultantsAsync();
}