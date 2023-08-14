namespace BookMyShow.DomainModels
{
    public class BookingRequest
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string TheatreName { get; set; }
        public int TheatreId { get; set; }
        public string ShowTime { get; set; }
        public float TotalAmount { get; set; }
        public DateTime Date { get; set; }
        public List<string> SeatNumbers { get; set; }
    }
}
