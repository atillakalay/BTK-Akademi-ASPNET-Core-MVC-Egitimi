﻿namespace Entities.Models;
public class Product
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; } = String.Empty;
    public decimal? Price { get; set; }
}