using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Game.Models;

public class GamerRankViewModel
{
    public List<Gamer>? Gamers { get; set; }
    public SelectList? Rank { get; set; }
    public string? GamerRank { get; set; }
    public string? SearchString { get; set; }
}