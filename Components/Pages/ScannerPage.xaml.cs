using ZXing.Net.Maui;

namespace ScanCart.Components.Pages;

public partial class ScannerPage : ContentPage
{
    private readonly TaskCompletionSource<string?> _barcodeSource;
    private bool _barcodeFound = false;

    public ScannerPage(TaskCompletionSource<string?> barcodeSource)
    {
        InitializeComponent();

        _barcodeSource = barcodeSource;

        cameraBarcodeReaderView.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.OneDimensional,
            AutoRotate = true,
            Multiple = false,
            TryHarder = true,
            DelayBetweenAnalyzingFrames = 50,
            InitialDelayBeforeAnalyzingFrames = 300,
            DelayBetweenContinuousScans = 1000
        };

        cameraBarcodeReaderView.BarcodesDetected += BarcodesDetected;
    }

    private void BarcodesDetected(
    object sender,
    BarcodeDetectionEventArgs e)
    {
        if (_barcodeFound)
        {
            return;
        }

        var barcode = e.Results.FirstOrDefault();

        if (barcode == null)
        {
            return;
        }

        _barcodeFound = true;

        MainThread.BeginInvokeOnMainThread(async () =>
        {
            barcodeResult.Text = $"Code: {barcode.Value}";

            _barcodeSource.SetResult(barcode.Value);

            await Navigation.PopModalAsync();
        });
    }
}