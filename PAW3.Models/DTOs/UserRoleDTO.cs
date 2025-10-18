using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PAW3.Models.DTOs;

public class UserRoleDTO
{
    [JsonPropertyName("id")]
    public decimal? Id { get; set; }
    [JsonPropertyName("rolId")]
    public int? RoleId { get; set; }
    [JsonPropertyName("userId")]
    public decimal? UserId { get; set; }
}
