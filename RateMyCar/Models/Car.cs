using System.ComponentModel.DataAnnotations.Schema;

namespace RateMyCar.Models
{
    [Table("car")]
    public class Car
    {
        [Column("car_id")]
        public int CarId { get; set; }

        [Column("make", TypeName = "varchar(200)")]
        public required string Make { get; set; }

        [Column("model", TypeName = "varchar(200)")]
        public required string Model { get; set; }

        [Column("year")]
        public required int Year { get; set; }


    }
}
