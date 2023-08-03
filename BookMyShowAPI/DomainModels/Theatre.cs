namespace DomainModels
{
    public class Theatre
    {
        public int Id { get; set; }
        public string? TheatreName { get; set; }
        public int? TheatreRows { get; set; }
        public int? TheatreColumns { get; set; }
        public List<int>? MovieIds { get; set; }
        public List<TimeOnly>? MovieTimings { get; set; }
        public string? LocationName { get; set; }
        public float TicketPrice { get; set; }
    }
}
