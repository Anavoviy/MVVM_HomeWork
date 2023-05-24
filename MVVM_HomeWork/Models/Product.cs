using System;
using System.Collections.Generic;
using MVVM_HomeWork.OtherFIles;

namespace MVVM_HomeWork;

public partial class Product
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int IdCategory { get; set; }

    public int IdProvider { get; set; }

    public decimal? CostOfOne { get; set; }

    public sbyte? Discount { get; set; }

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual Provider IdProviderNavigation { get; set; } = null!;
}
