namespace BookMyShow.DomainModels
{
    public class Theatre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public List<int> MovieIds { get; set; }
        public List<TimeOnly> ShowTime { get; set; }
        public string Location { get; set; }
        public float TicketPrice { get; set; }
    }
}
