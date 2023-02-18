using System;
using System.Collections.Generic;

namespace ToolRental.API.Models;

/// <summary>
/// Информация о пользователе
/// </summary>
public partial class User
{
    /// <summary>
    /// ID пользователя
    /// </summary>
    public uint Id { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string Firstname { get; set; } = null!;

    /// <summary>
    /// Фамилия
    /// </summary>
    public string Lastname { get; set; } = null!;

    /// <summary>
    /// Логин
    /// </summary>
    public string Login { get; set; } = null!;

    /// <summary>
    /// Пароль
    /// </summary>
    public string Md5password { get; set; } = null!;

    /// <summary>
    /// Является администратором
    /// </summary>
    public uint IsAdmin { get; set; }

    public virtual ICollection<RentalOrder> RentalOrders { get; } = new List<RentalOrder>();
}
