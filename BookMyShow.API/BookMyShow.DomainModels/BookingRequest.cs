namespace BookMyShow.DomainModels
{
    public class BookingRequest
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string TheatreName { get; set; }
        public int TheatreId { get; set; }
        public string MovieTimings { get; set; }
        public float TotalAmount { get; set; }
        public DateTime Date { get; set; }
        public int SeatsCount { get; set; }
        public List<int> SeatNumbers { get; set; }
    }
}
