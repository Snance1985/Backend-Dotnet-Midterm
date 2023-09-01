using System.ComponentModel.DataAnnotations;

namespace midterm_project.Models;

public class Shop
{
    public int ShopId { get; set; }
    [Required(ErrorMessage = "We gotta know the dino's name!"), StringLength(50)]
    [Display(Name = "Dino Names!")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "We gotta have pictures of every dinosaur!"), Url(ErrorMessage = "Enter a valid Dino pic Url.")]
    [Display(Name = "Say Cheese!")]
    public string? ImgUrl { get; set; }
    [Required(ErrorMessage = "A description of every dino is needed!"), StringLength(500)]
    [Display(Name = "All about dinos!")]
    public string? Description { get; set; }
    [Required(ErrorMessage = "The type of dino is required! Ex: Carnivore, Herbavore, Omnivore.")]
    [Display(Name = "What they eat!")]
    public string? TypeOfDino { get; set; }
    [Required(ErrorMessage = "The price of the dino is required!"), Range(3000, 100000, ErrorMessage = "You must enter a price between 3000 and 100000.")]
    [Display(Name = "Dino Prices!")]
    public double? Price { get; set; }
}

