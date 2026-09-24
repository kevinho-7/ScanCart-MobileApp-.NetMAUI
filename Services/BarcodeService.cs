using ScanCart.Components.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScanCart.Services
{
    public class BarcodeService
    {
       public async Task OpenScannerAsync()
        {
            // --> Takes MUAIs main page
            var page = Application.Current?.Windows[0].Page; 

            if(page == null)
            {
                return;
            }

            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                // --> (page.Navigation: access MAUIs system navigation)
                // --> (PushModalAsync(new ScannerPage()) Open the freaking ScannerPage
                await page.Navigation.PushModalAsync(new ScannerPage());   
            });
        }
    }
}
