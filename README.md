# ScanCart

## Overview

ScanCart is a mobile app for scanning product barcodes and viewing product information. It uses the Open Food Facts API to find a product by its barcode.

The app shows the product name, brand, image, and quantity when this information is available.

## Development Environment

This project uses:

- .NET 10 and C#
- .NET MAUI
- Blazor Hybrid
- ZXing.Net.Maui for barcode scanning
- Open Food Facts API for product data
- Tailwind CSS and Flowbite for styles
- Visual Studio with the .NET MAUI workload

The project is intended to run on Android.

## Project Organization

```text
ScanCart/
├── Components/
│   ├── Layout/              App layout and navigation
│   └── Pages/               Home, scan, product, and scanner pages
├── Models/                  Product API data models
├── Platforms/               Android platform files
├── Resources/               App icon, fonts, images, and other assets
├── Services/
│   ├── BarcodeService.cs    Opens the camera scanner
│   ├── ProductService.cs    Gets product data from Open Food Facts
│   └── LocalStorageService.cs Local browser storage access
├── wwwroot/                 Blazor web assets and styles
├── MauiProgram.cs           App setup and service registration
└── ScanCart.csproj          .NET MAUI project settings
```

## Main Features

- Scan a one-dimensional product barcode with the device camera.
- Search Open Food Facts using the scanned barcode.
- View available product details: name, brand, image, and quantity.

An internet connection is needed to look up products. The app also needs camera access to scan barcodes. Product information depends on the data available in Open Food Facts.

## Run the App

### Requirements

- .NET 10 SDK with the .NET MAUI workload
- Visual Studio with .NET MAUI support
- Android emulator or Android device for Android development

### Build for Android

From the project folder, restore the MAUI workloads and build the Android target:

```bash
dotnet workload restore
dotnet build ScanCart.csproj -f net10.0-android
```

To launch the app, select an Android emulator or connected device in Visual Studio and start the project.

### Update the CSS

The project uses npm to build Tailwind CSS. From the project folder, run:

```bash
npm install
npm run css
```

Keep this process running while you work on the CSS files.

## Useful Websites

- [.NET MAUI Documentation](https://learn.microsoft.com/dotnet/maui/)
- [Blazor Documentation](https://learn.microsoft.com/aspnet/core/blazor/)
- [ZXing.Net.Maui](https://github.com/Redth/ZXing.Net.Maui)
- [Open Food Facts API](https://openfoodfacts.github.io/openfoodfacts-server/api/)
- [Tailwind CSS Documentation](https://tailwindcss.com/docs)
