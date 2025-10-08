using Microsoft.AspNetCore.Mvc;
using PAW3.Models.DTOs;

namespace PAW3.Mvc.Models;

public class UserViewModel
{
    public string Title { get; set; } = "My App";
    public IEnumerable<string> Items { get; set; } = [];
    public object Dog { get; set; }
    public IEnumerable<UserDTO> Users { get; set; } = [];


}

