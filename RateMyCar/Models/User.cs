using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateMyCar.Models
{
    [Table("users")]
    public class User
    {
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("username", TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Column("email", TypeName = "varchar(200)")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Column("password", TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Password must be at least 8 characters long and contain an uppercase letter, a lowercase letter, a number, and a special character.")]
        public string Password { get; set; }

        [Column("full_name", TypeName = "varchar(200)")]
        [Required(ErrorMessage = "Fullname is required")]
        public string Fullname { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
