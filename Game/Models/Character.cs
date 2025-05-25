using System.ComponentModel.DataAnnotations;

public class Character
{
    public int Id { get; set; }
    [StringLength(60, MinimumLength =3)]
    [Required]
    [RegularExpression(@"^[А-Я]+[а-яА-Я\s]*$")]
    [Display(Name = "Имя")]
    public string? Name { get; set; }
    [Display(Name = "Оружие")]
    public string? Weapon { get; set; }
    [Display(Name = "ID_уровня")]
    public int? Level_ID { get; set; }
    public Level? Level { get; set; }
    [Display(Name = "ID_игрока")]
    public int? Gamer_ID { get; set; }
    public Gamer? Gamer { get; set; }
}
