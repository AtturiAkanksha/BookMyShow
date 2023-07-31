namespace DomainModels
{
    public class Theatres
    {
        public int Id { get; set; }
        public string? TheatreName { get; set; }
        public int? TheatreRows { get; set; }
        public int? TheatreColumns { get; set; }
        public List<Movies>? ListOfMovies { get; set; }
        public string? MovieTimings { get; set; }
        public int TicketPrice { get; set; }
    }
}
