using GetMygeek.Data.ORM;
using GetMygeek.Models;

namespace GetMygeek.Data;
public interface IDatabaseService
{
    /// <summary>
    /// Fonction qui récupère tous les enregistrements de la table "consultant"
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Consultant>> GetAllConsultantsAsync();

    /// <summary>
    /// Fonction qui récupère les consultants correspondant aux filtres de la barre de recherche.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Consultant>> GetConsultantsResearchBar(ResearchQuery researchQuery);
}