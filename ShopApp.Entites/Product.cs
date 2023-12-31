﻿namespace ShopApp.Entites
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int Price { get; set; }
        public string? Gender { get; set; }
        public string? Condition { get; set; }


        public List<ProductCategory>? ProductCategories { get; set; }
    }
}
