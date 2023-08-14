namespace BookMyShow.DomainModels
{
    public class ReservedSeat
    {
        public string SeatNumber { get; set; }
        public int TheatreId { get; set; }
        public int MovieId { get; set; }
        public string ShowTime { get; set; }
    }
}
