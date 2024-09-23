using GetMygeek.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace GetMygeek.Components.Pages
{
    public partial class Card
    {
        [Parameter]
        public Phototeque Profil { get; set; }

        #region DDC Message Box
        public MudMessageBox _mudMessageBox;


        /// <summary>
        /// Cette fonction permet d'afficher la fenetre MudMessage qui contient le DDC [Dossier De Compétence]
        /// </summary>
        /// <returns></returns>
        public async Task OpenDDCInformationAsync()
        {
            bool? result = await _mudMessageBox.ShowAsync();
        }
        #endregion
    }
}
