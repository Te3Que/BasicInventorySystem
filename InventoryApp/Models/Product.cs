namespace InventoryApp.Models;

public class Product
    {
        public string? _id { get; set; }
        public string productName { get; set; } = null!;
        public int productAmount { get; set; }
        public string productLocation { get; set; }
        public string productBarcode { get; set; }
    }