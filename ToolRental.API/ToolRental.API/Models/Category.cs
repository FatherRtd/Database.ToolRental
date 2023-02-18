using System;
using System.Collections.Generic;

namespace ToolRental.API.Models;

/// <summary>
/// Категория товара
/// </summary>
public partial class Category
{
    /// <summary>
    /// Индекс категории
    /// </summary>
    public uint Id { get; set; }

    /// <summary>
    /// Название категории
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Индекс родительской категории
    /// </summary>
    public uint? ParentId { get; set; }

    public virtual ICollection<Category> InverseParent { get; } = new List<Category>();

    public virtual Category? Parent { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
