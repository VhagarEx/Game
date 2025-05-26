using System.ComponentModel.DataAnnotations;

public class Level
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле 'Уровень' обязательно для заполнения")]
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Уровень должен быть положительным числом")]
    [Display(Name = "Уровень")]
    public string? Level_Number { get; set; }

    [Required(ErrorMessage = "Поле 'Бонус' обязательно для заполнения")]
    [StringLength(100, ErrorMessage = "Бонус не должен превышать 100 символов")]
    [Display(Name = "Бонус")]
    public string? Bonus { get; set; }

    [Required(ErrorMessage = "Поле 'Способность' обязательно для заполнения")]
    [StringLength(200, ErrorMessage = "Способность не должна превышать 200 символов")]
    [Display(Name = "Способность")]
    public string? Capability { get; set; }

    public ICollection<Character> Characters { get; set; } = new List<Character>();
}
