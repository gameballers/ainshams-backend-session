using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Models;
using SocialMediaApp.ViewModels;

namespace SocialMediaApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly SocialMediaContext _context;
        public CommentsController(SocialMediaContext context)
        {
            _context = context;
        }
        [HttpPost]
        public ActionResult AddComment([FromBody] CreateCommentViewModel model)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == model.PostId);
            if (post == null)
            {
                return NotFound("Post not found");
            }

            var newComment = new Comment
            {
              
                PostId = model.PostId,
                Content = model.Content,
                AuthorId = model.AuthorId
            };

           _context.Comments.Add(newComment);
            _context.SaveChanges();
            return Ok();
        }
    }

}