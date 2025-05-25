using System.ComponentModel.DataAnnotations;

public class Level
{
    public int Id { get; set; }
    [Display(Name ="Уровень")]
    public string? Level_Number { get; set; }
    [Display(Name = "Бонус")]
    public string? Bonus { get; set; }
    [Display(Name = "Способность")]
    public string? Capability { get; set; }

    public ICollection<Character> Characters { get; set; } = new List<Character>();
}
