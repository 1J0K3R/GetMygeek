using GetMygeek.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace GetMygeek.Components.Pages;
public partial class Card
{
    /// <summary>
    /// Objet Profil qui contient toutes les informations d'un consultant 
    /// </summary
    [Parameter]
    public Phototeque Profil { get; set; }

    /// <summary>
    /// Popup qui récupère et affiche la mission du consultant
    /// </summary>
    private MissionPopup missionPopup;

    /// <summary>
    /// Cette fonction permet d'afficher la popup qui contient la mission en cours d'un consultant
    /// </summary>
    /// <returns></returns>
    public async Task OpenMissionInformationAsync()
    {
        await missionPopup.ShowAsync();
    }
}