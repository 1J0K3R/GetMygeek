using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace GetMygeek.Components.Pages
{
    public partial class Card
    {
        [Parameter]
        public string Trigramme { get; set; }

        [Parameter]
        public string Name { get; set; }

        [Parameter]
        public string Poste { get; set; }

        [Parameter]
        public string PhoneNumber { get; set; }

        [Parameter]
        public string Mail { get; set; }

        [Parameter]
        public bool Libre { get; set; }

        #region DDC Message Box
        private MudMessageBox _mudMessageBox;
        private string _state = "Message box hasn't been opened yet";

        public async Task OpenDDCInformationAsync()
        {
            bool? result = await _mudMessageBox.ShowAsync();
            _state = result is null ? "Canceled" : "Deleted!";
            StateHasChanged();

            Console.WriteLine("azzrerefre");
        }
        #endregion
    }
}
