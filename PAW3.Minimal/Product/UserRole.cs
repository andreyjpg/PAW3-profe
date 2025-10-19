using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

public partial class UserRole
{

    [Key]
    public decimal Id { get; set; }

    public decimal? RoleId { get; set; }

    public decimal? UserId { get; set; }
}
