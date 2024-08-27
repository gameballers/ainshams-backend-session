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

			if(result == null)
			{
				return NotFound("Author not found");
			}

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
	}
}
