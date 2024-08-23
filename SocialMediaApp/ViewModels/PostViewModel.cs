namespace SocialMediaApp.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string AuthorName { get; set; }
        public List<string> Comments { get; set; } = new List<string>();
    }
}
