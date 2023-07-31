namespace DomainModels
{
    public class Movies
    {
        public int Id { get; set; }
        public string? MovieName { get; set; }
        public string Languages { get; set; }
        public string Hours { get; set; }
        public string Genre { get; set; }
        public string DateOfRelease { get; set; }
        public string? LocationNames { get; set; }
        public int TheatresId { get; set; }
    }
}
