using SocialMediaApp.Models;

namespace SocialMediaApp.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public AuthorViewModel? Author { get; set; }
    }
}
