using ScanCart.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ScanCart.Services
{
    public class ProductService
    {
        public Product? CurrentProduct { get; private set; }

        public async Task<Product?> GetProductAsync(string barcode)
        {
            HttpClient client = new HttpClient();

            string url = $"https://world.openfoodfacts.net/api/v3.6/product/{barcode}.json";

            var findProduct = await client.GetAsync(url);
            var json = await findProduct.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<ProductResponse>(json);
            var product = response?.Product;

            CurrentProduct = product;

            return product;
        }

    }
}
