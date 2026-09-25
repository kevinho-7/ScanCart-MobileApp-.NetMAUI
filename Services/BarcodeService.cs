using ScanCart.Components.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScanCart.Services
{
    public class BarcodeService
    {
       public async Task<string> ScanAsync()
        {
            var source = new TaskCompletionSource<string?>();

            // --> It takes MUAIs main page
            var page = Application.Current?.Windows[0].Page; 

            if(page == null)
            {
                return null!;
            }

            var scannerPage = new ScannerPage(source);

            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                // --> (page.Navigation: It access MAUIs system navigation)
                // --> (PushModalAsync(new ScannerPage()) It     opens the freaking ScannerPage
                await page.Navigation.PushModalAsync(scannerPage);   

            });

            var barcode = await source.Task;

            return barcode!;
        }
    }
}
