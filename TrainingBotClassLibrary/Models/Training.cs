namespace BookingApi.Models
{
    public class Service
    {
        public int Id { get; set; }
        public int MasterId { get; set; }
        public string title { get; set; } = null!;
        public int duration_min { get; set; }
        public decimal price { get; set; } = null!;
    }
}