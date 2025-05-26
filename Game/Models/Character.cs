using System.ComponentModel.DataAnnotations;

public class Character
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Поле 'Имя' обязательно для заполнения")]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "Имя должно быть от 3 до 60 символов")]
    [RegularExpression(@"^[А-Я]+[а-яА-Я\s]*$",
        ErrorMessage = "Имя должно начинаться с заглавной буквы и содержать только русские буквы")]
    [Display(Name = "Имя")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Поле 'Оружие' обязательно для заполнения")]
    [StringLength(50, ErrorMessage = "Название оружия не должно превышать 50 символов")]
    [Display(Name = "Оружие")]
    public string? Weapon { get; set; }

    [Required(ErrorMessage = "Поле 'ID уровня' обязательно для заполнения")]
    [Display(Name = "ID уровня")]
    public int? LevelId { get; set; }

    public Level? Level { get; set; }

    [Required(ErrorMessage = "Поле 'ID игрока' обязательно для заполнения")]
    [Display(Name = "ID игрока")]
    public int? GamerId { get; set; }
    public Gamer? Gamer { get; set; }
}
