using System.ComponentModel.DataAnnotations;

namespace onlinepizzawebapplication.Models
{
    public class Orders
    {
        [Key]
        public Guid orderid { get; set; }
        public string name{ get; set; }
        public string email { get; set; }
        public string address { get; set; }

    }
}
