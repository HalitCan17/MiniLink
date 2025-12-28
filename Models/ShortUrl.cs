namespace MiniLink.Models
{
    public class ShortUrl
    {

        public int Id { get; set; }

        public string OriginalUrl { get; set; }

        public string Code { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int ClickCount { get; set; } = 0;
    }
}