using System;
using System.Collections.Generic;

namespace ToolRental.API.Models;

/// <summary>
/// Информация о товаре
/// </summary>
public partial class Product
{
    /// <summary>
    /// ID товара
    /// </summary>
    public uint Id { get; set; }

    /// <summary>
    /// Наименование товара
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Краткое описание
    /// </summary>
    public string ShortDescription { get; set; } = null!;

    /// <summary>
    /// Полное описание
    /// </summary>
    public string LongDescription { get; set; } = null!;

    /// <summary>
    /// Цена аренды
    /// </summary>
    public uint RentalPrice { get; set; }

    /// <summary>
    /// Наличие товара
    /// </summary>
    public bool IsInStock { get; set; }

    /// <summary>
    /// Изображение товара
    /// </summary>
    public string Image { get; set; } = null!;

    /// <summary>
    /// Индекс категории
    /// </summary>
    public uint CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<RentalOrder> RentalOrders { get; } = new List<RentalOrder>();
}
