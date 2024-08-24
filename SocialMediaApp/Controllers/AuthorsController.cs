using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Models;
using SocialMediaApp.ViewModels;

namespace SocialMediaApp.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public partial class AuthorsController : ControllerBase
	{
		private readonly SocialMediaContext _context;
		private static List<Author> _authors = new List<Author>();

		public AuthorsController(SocialMediaContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<List<AuthorViewModel>>> GetAll()
		{
			var result = await _context.Authors.Select(a => new AuthorViewModel
			{
				Id = a.Id,
				Name = a.Name
			}).ToListAsync();

			return Ok(result);
		}

		[HttpGet("{Id}")]
		public async Task<ActionResult<AuthorViewModel>> GetAuthorById([FromRoute] int Id)
		{
			var result = await _context.Authors.Where(a => a.Id == Id).FirstOrDefaultAsync();

			return Ok(result);
		}

		[HttpPost]
		public async Task<ActionResult> Create([FromBody] AuthorViewModel model)
		{
			var newAuthor = new Author
			{
				Name = model.Name
			};

			_context.Authors.Add(newAuthor);
			await _context.SaveChangesAsync();

			return Ok();
		}

		[HttpDelete("{Id}")]
		public ActionResult Delete([FromRoute] int Id)
		{
			var author = _authors.Where(a => a.Id == Id).FirstOrDefault();

			if (author != null)
			{
				_authors.Remove(author);
			}
			return Ok();
		}

		[HttpPut("{Id}")]
		public ActionResult Update([FromRoute] int Id, [FromBody] AuthorViewModel model)
		{
			_authors.Find(a => a.Id == Id).Name = model.Name;

			return Ok();
		}
	}
}
