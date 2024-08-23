using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Models;
using SocialMediaApp.ViewModels;

namespace SocialMediaApp.Controllers
{

     [ApiController]
     [Route("api/[controller]")]
     public class PostsController : ControllerBase
     {
          public static List<Post> _posts = new List<Post>();
          private static List<Author> _authors = new List<Author>();

          [HttpGet]
          public ActionResult<List<PostViewModel>> GetAll()
          {
               var result = _posts.Select(p => new PostViewModel
               {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    AuthorName = _authors.FirstOrDefault(a => a.Id == p.AuthorId)?.Name,
                    Comments = p.Comments.Select(c => c.Content).ToList()
               }).ToList();

               return Ok(result);
          }

          [HttpPost]
          public ActionResult Create([FromBody] CreatePostViewModel model)
          {
               var author = _authors.FirstOrDefault(a => a.Id == model.AuthorId);
               if (author == null)
               {
                    return NotFound("Author not found");
               }

               var newPost = new Post
               {
                    Id = _posts.Count + 1,
                    Title = model.Title,
                    Content = model.Content,
                    AuthorId = model.AuthorId,
                    Author = author
               };

               _posts.Add(newPost);
               return Ok();
          }

          [HttpGet]
          [Route("/{Id}")]
          public ActionResult<PostViewModel> GetById([FromRoute] int Id)
          {
               var result = _posts.Where(a => a.Id == Id).FirstOrDefault();

               return Ok(result);
          }


          [HttpDelete]
          [Route("/{Id}")]
          public ActionResult Delete([FromRoute] int Id)
          {
               var post = _posts.Where(a => a.Id == Id).FirstOrDefault();

               if (post != null)
               {
                    _posts.Remove(post);
               }
               return Ok();
          }

          [HttpPut]
          [Route("/{Id}")]
          public ActionResult Update([FromRoute] int Id, [FromBody] PostViewModel model)
          {
               _posts.Find(a => a.Id == Id).Content = model.Content;

               return Ok();
          }
     }
}

