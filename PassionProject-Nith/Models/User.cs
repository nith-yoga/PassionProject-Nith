using System.ComponentModel.DataAnnotations;

namespace PassionProject_Nith.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string Password { get; set; }
    }
}
