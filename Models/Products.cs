﻿using System.ComponentModel;

namespace CleanArchitecture.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Categories Category { get; set; }
    }
}
