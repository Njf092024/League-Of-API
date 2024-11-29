namespace LeagueOfAPI.Models;
using Microsoft.EntityFrameworkCore;

public class Champion
{
public int Id {get; set; }
public string Name {get; set; } = string.Empty;
public string Role {get; set; } = string.Empty;
public int Difficulty { get; set; }
}