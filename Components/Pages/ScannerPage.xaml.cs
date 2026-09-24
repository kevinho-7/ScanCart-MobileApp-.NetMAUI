using ZXing.Net.Maui;

namespace ScanCart.Components.Pages;

public partial class ScannerPage : ContentPage
{
	public ScannerPage()
	{
		InitializeComponent();

        cameraBarcodeReaderView.BarcodesDetected += BarcodesDetected!;
    }

    protected async void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        foreach(var barcode in e.Results)
        {
            await DisplayAlertAsync(
                "Barcode detected",
                $"Code: {barcode.Value}",
                "Ok"
            );

            Console.WriteLine($"Code: {barcode.Value}");
        }
    }
}