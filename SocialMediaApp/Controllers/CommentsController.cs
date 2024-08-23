using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Models;
using SocialMediaApp.ViewModels;

namespace SocialMediaApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        [HttpPost]
        public ActionResult AddComment([FromBody] CreateCommentViewModel model)
        {
            var post = PostsController._posts.FirstOrDefault(p => p.Id == model.PostId);
            if (post == null)
            {
                return NotFound("Post not found");
            }

            var newComment = new Comment
            {
                Id = post.Comments.Count + 1,
                PostId = model.PostId,
                Content = model.Content
            };

            post.Comments.Add(newComment);
            return Ok();
        }
    }

}