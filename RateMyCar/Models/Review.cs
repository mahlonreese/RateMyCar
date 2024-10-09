using System.ComponentModel.DataAnnotations.Schema;

namespace RateMyCar.Models
{
    [Table("review")]
    public class Review
    {
        [Column("review_id")]
        public int ReviewId { get; set; }

        [Column("rating")]
        public int Rating { get; set; }

        [Column("comments")]
        public string Comments { get; set; }

        [Column("photo_url")]
        public string PhotoUrl { get; set; }

        [Column("date_posted")]
        public DateTime DatePosted { get; set; }


        [ForeignKey("User")]
        [Column("user_id")]
        public int UserId { get; set; }
        public User User { get; set; }


        [ForeignKey("Car")]
        [Column("car_id")]
        public int CarId { get; set; }
        public Car Car { get; set; }  


    }
}
