using System.ComponentModel.DataAnnotations;

namespace onlinepizzawebapplication.Models
{
    public class login
    {
        [Key]
        public Guid loginid { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
