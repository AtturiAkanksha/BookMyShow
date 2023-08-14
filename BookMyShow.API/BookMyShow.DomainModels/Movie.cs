namespace BookMyShow.DomainModels
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public string Duration { get; set; }
        public string Genre { get; set; }
        public DateTime DateOfRelease { get; set; }
    }
}
