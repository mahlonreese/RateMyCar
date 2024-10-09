using System.ComponentModel.DataAnnotations.Schema;

namespace RateMyCar.Models
{
    [Table("user")]
    public class User
    {
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("username", TypeName = "varchar(100)")]
        public required string Username { get; set; }

        [Column("email", TypeName = "varchar(200)")]
        public required string Email { get; set; }

        [Column("password", TypeName = "varchar(100)")]
        public required string Password { get; set; }
    }
}
