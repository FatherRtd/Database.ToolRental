using System;
using System.Collections.Generic;

namespace ToolRental.API.Models;

/// <summary>
/// Информация о заказе
/// </summary>
public partial class RentalOrder
{
    /// <summary>
    /// Индекс заказа
    /// </summary>
    public uint Id { get; set; }

    /// <summary>
    /// Индекс пользователя
    /// </summary>
    public uint UserId { get; set; }

    /// <summary>
    /// Индекс товара
    /// </summary>
    public uint ProductId { get; set; }

    /// <summary>
    /// Дата и время начала аренды
    /// </summary>
    public DateTime? OrderDate { get; set; }

    /// <summary>
    /// Дата и время окончания аренды
    /// </summary>
    public DateTime? OrderEndDate { get; set; }

    /// <summary>
    /// Цена аренды
    /// </summary>
    public uint? RentalPrice { get; set; }

    /// <summary>
    /// Заказ завершён
    /// </summary>
    public bool IsDone { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
