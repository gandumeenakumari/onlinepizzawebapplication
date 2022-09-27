using System.ComponentModel.DataAnnotations;

namespace onlinepizzawebapplication.Models
{
    public class Categories
    {
        [Key]
        public Guid categoryid { get; set; }
        public string categoryname { get; set; }
    }
}
