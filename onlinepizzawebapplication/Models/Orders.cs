using System.ComponentModel.DataAnnotations;

namespace onlinepizzawebapplication.Models
{
    public class Orders
    {
        [Key]
        public Guid orderid { get; set; }
        public string category { get; set; }
        public string pizzaname { get; set; }
        public int price { get; set; }
    }
}
