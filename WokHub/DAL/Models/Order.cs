using System.ComponentModel.DataAnnotations;

namespace WokHub.DAL.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public DateTime OrderTime { get; set; }
        public DateTime DeliveryTime { get; set; }

        public string? Address { get; set; }

        // >>>

        public List<OrderDishPile> Dishes { get; set; }

        public User User { get; set; }

        // <<<
    }

    public enum OrderStatus
    {
        InProgress,
        Delivered
    }
}
