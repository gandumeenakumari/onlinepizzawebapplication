using System.ComponentModel.DataAnnotations;

namespace onlinepizzawebapplication.Models
{
    public class Reviews
    {
        [Key]
        public Guid reviewid { get; set; }
        public string category { get; set; }
        public string pizzaname { get; set; }
        public int rating { get; set; }
        public string description { get; set; }
    }
}
