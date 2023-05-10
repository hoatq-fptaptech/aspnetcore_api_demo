using System;
using System.Collections.Generic;

namespace DemoAPI.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public string Thumbnail { get; set; } = null!;
}
