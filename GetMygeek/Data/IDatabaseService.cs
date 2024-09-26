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
    /// Fonction qui récupère la mission d'un consultant
    /// </summary>
    /// <param name="idMission">Id de la mission du consultant à récupérer</param>
    /// <returns></returns>
    Task<Mission> GetMissionAsync(long? idMission);

    /// <summary>
    /// Fonction qui récupère les consultants correspondant aux filtres de la barre de recherche.
    /// </summary>
    /// <param name="researchQuery">Contient tous les paramètres de recherche</param>
    /// <returns></returns>
    Task<IEnumerable<Consultant>> GetConsultantsResearchBar(ParametreRecherche researchQuery);
}