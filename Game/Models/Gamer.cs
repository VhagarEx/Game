using System.ComponentModel.DataAnnotations;

public class Gamer
{
    public int Id { get; set; }
    [RegularExpression(@"^[А-Я]+[а-яА-Я\s]*$")]
    [Display(Name="Фамилия")]
    public string? Surname { get; set; }
    [RegularExpression(@"^[А-Я]+[а-яА-Я\s]*$")]
    [Display(Name = "Имя")]
    public string? Name { get; set; }
    [DataType(DataType.Date)]
    [Display(Name = "Дата регистрации")]
    public DateTime DataRegistr { get; set; }
    [Display(Name = "Почта")]
    public string? Email { get; set; }
    [Display(Name = "Пароль")]
    public string? Paswd { get; set; }
    [Display(Name = "Ранг")]
    public string? Rank { get; set; }

    public ICollection<Character> Characters { get; set; } = new List<Character>();

}
