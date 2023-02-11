namespace WokHub.DAL.Models
{
    public class DishPile
    {
        public Dish Dish { get; set; }

        public int Number { get; set; }
    }

    public class OrderDishPile : DishPile
    {
        public Order Order { get; set; }
    }

    public class CartDishPile : DishPile
    {
        public User User { get; set; }
    }
}
