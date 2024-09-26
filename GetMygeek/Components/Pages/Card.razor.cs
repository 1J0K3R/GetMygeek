using GetMygeek.Data.ORM;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Reflection.Metadata.Ecma335;

namespace GetMygeek.Components.Pages;
public partial class Card
{
    /// <summary>
    /// Objet Profil qui contient toutes les informations d'un consultant 
    /// </summary
    [Parameter]
    public Consultant Profil { get; set; }

    /// <summary>
    /// Popup qui récupère et affiche la mission du consultant
    /// </summary>
    private MissionPopup missionPopup;

    /// <summary>
    /// Chaine qui reprend les domaines de préférence du consultant
    /// </summary>
    private string preferenceDomainString { get; set; }

    /// <summary>
    /// Cette fonction permet d'afficher la popup qui contient la mission en cours d'un consultant
    /// </summary>
    /// <returns></returns>
    public async Task OpenMissionInformationAsync()
    {
        await missionPopup.ShowAsync();
    }

    /// <summary>
    /// Methode d'initialisation de l'objet
    /// </summary>
    /// <returns></returns>
    protected override async Task OnInitializedAsync()
    {
        // Lire et désérialiser le fichier JSON lors de l'initialisation
        if(Profil.IdPrefDomain is null)
        {
            new Exception("L'id de preference domaine est null");
        }
        else
        {
            preferenceDomainString = await GetPreferenceDomainBySqlRequestAsync(Profil.IdPrefDomain);
        }
    }

    private async Task<string> GetPreferenceDomainBySqlRequestAsync(long? IdPrefDomain)
    {
        // Récupérer les préférence de domaine du consultant en interrogeant la base sql avec i 'ID de preference du domaine 
        PreferenceDomain resultPreferenceDomain = new()
        {
            IdPrefDomain = IdPrefDomain,
        };

        if(IdPrefDomain == 1 || IdPrefDomain == 4 || IdPrefDomain == 6 || IdPrefDomain == 7){
                resultPreferenceDomain.Dev=true;
            }
        if(IdPrefDomain == 2 || IdPrefDomain == 4 || IdPrefDomain == 5 || IdPrefDomain == 7){
            resultPreferenceDomain.Fonctionnel=true;
        }
        if(IdPrefDomain == 3 || IdPrefDomain == 5 || IdPrefDomain == 6 || IdPrefDomain == 7){
            resultPreferenceDomain.Infra=true;
        }

        return ConstruirePreferenceString(resultPreferenceDomain);
    }

    private string ConstruirePreferenceString(PreferenceDomain preference)
    {
        List<string> domaines = new List<string>();

        if (preference.Dev)
            domaines.Add("Dev");

        if (preference.Fonctionnel)
            domaines.Add("Fonctionnel");

        if (preference.Infra)
            domaines.Add("Infra");

        return string.Join(" / ", domaines);
    }
}