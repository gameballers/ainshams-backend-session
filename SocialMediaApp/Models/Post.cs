using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace SocialMediaApp.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public List<Comment> Comments { get; set; }

    }

}
