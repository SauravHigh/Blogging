namespace BloggingApp.Models
{
    public class Posts
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
        
        public int Category { get; set; }

        public long AuthorId { get; set; }
    }
}
