using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ScanCart.Models
{
    public class ProductResponse
    {
        [JsonPropertyName("product")]
        public Product? Product { get; set; }
    }
}
