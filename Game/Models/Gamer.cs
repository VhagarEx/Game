using System.ComponentModel.DataAnnotations;

public class Gamer
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле 'Фамилия' обязательно для заполнения")]
    [RegularExpression(@"^[А-Яа-яЁё\s-]+$", ErrorMessage = "Фамилия должна содержать только русские буквы, пробелы и дефисы")]
    [Display(Name = "Фамилия")]
    public string? Surname { get; set; }

    [Required(ErrorMessage = "Поле 'Имя' обязательно для заполнения")]
    [RegularExpression(@"^[А-Я]+[а-яА-Я\s]*$", ErrorMessage = "Имя должно начинаться с заглавной буквы и содержать только русские буквы")]
    [Display(Name = "Имя")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Поле 'Дата регистрации' обязательно для заполнения")]
    [DataType(DataType.Date)]
    [Display(Name = "Дата регистрации")]
    public DateTime DataRegistr { get; set; }

    [Required(ErrorMessage = "Поле 'Почта' обязательно для заполнения")]
    [EmailAddress(ErrorMessage = "Введите корректный email адрес")]
    [Display(Name = "Почта")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Поле 'Пароль' обязательно для заполнения")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Пароль должен быть от 6 до 100 символов")]
    [DataType(DataType.Password)]
    [Display(Name = "Пароль")]
    public string? Paswd { get; set; }

    [Required(ErrorMessage = "Поле 'Ранг' обязательно для заполнения")]
    [Display(Name = "Ранг")]
    public string? Rank { get; set; }

    public ICollection<Character> Characters { get; set; } = new List<Character>();

}
