using System;
using System.Collections.Generic;
using MVVM_HomeWork.OtherFIles;

namespace MVVM_HomeWork;

public partial class Category
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
