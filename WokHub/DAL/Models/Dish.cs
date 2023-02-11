using System.ComponentModel.DataAnnotations;

namespace WokHub.DAL.Models
{
    public class Dish
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double? Price { get; set; }

        public string? Description { get; set; }

        public bool? IsVegeterian { get; set; }

        public string? Photo { get; set; }

        public DishCategory Category { get; set; }
    }

    public enum DishCategory
    {
        WOK,
        Pizza,
        Soup,
        Dessert,
        Drink
    }
}
