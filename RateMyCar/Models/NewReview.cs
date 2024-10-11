namespace RateMyCar.Models
{
    public class NewReview
    {
        public int Rating { get; set; }
        public string? Comments { get; set; }
        public string? PhotoUrl { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }
    }
}
