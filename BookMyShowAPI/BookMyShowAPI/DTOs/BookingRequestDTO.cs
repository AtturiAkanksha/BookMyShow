namespace BookMyShowWeb.DTOs
{
    public class BookingRequestDTO
    {
        public string MovieName { get; set; }
        public string TheatreName { get; set; }
        public int TheatreId { get; set; }
        public string MovieTimings { get; set; }
        public float TotalAmount { get; set; }
        public DateTime Date { get; set; }
        public int SeatsCount { get; set; }
        public List<int> SeatsNames { get; set; }
    }
}
