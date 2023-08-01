namespace DomainModels
{
    public class Theatre
    {
        public int Id { get; set; }
        public string? TheatreName { get; set; }
        public int? TheatreRows { get; set; }
        public int? TheatreColumns { get; set; }
        public List<int>? MovieIds { get; set; }
        public string? MovieTimings { get; set; }
        public string? LocationName { get; set; }
        public int TicketPrice { get; set; }
    }
}
