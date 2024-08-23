using static System.Net.Mime.MediaTypeNames;

namespace SocialMediaApp.Models
{

    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }

    }
}
