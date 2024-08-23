using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Models;
using SocialMediaApp.ViewModels;

namespace SocialMediaApp.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AuthorsController : ControllerBase
	{
		private static List<Author> _authors = new List<Author>();

		[HttpGet]
		public ActionResult<List<AuthorViewModel>> GetAll()
		{
			var result = _authors.Select(a => new AuthorViewModel
			{
				Id = a.Id,
				Name = a.Name
			}).ToList();

			return Ok(result);
		}

		[HttpGet]
		[Route("/{Id}")]
		public ActionResult<AuthorViewModel> GetById([FromRoute] int Id)
		{
			var result = _authors.Where(a => a.Id == Id).FirstOrDefault();

			return Ok(result);
		}

		[HttpPost]
		public ActionResult Create([FromBody] AuthorViewModel model)
		{
			var newAuthor = new Author
			{
				Id = _authors.Count + 1,
				Name = model.Name
			};

			_authors.Add(newAuthor);
			return Ok();
		}

		[HttpDelete]
		[Route("/{Id}")]
		public ActionResult Delete([FromRoute] int Id)
		{
			var author = _authors.Where(a => a.Id == Id).FirstOrDefault();

			if (author != null)
			{
				_authors.Remove(author);
			}
			return Ok();
		}

		[HttpPut]
		[Route("/{Id}")]
		public ActionResult Update([FromRoute] int Id, [FromBody] AuthorViewModel model)
		{
			_authors.Find(a => a.Id == Id).Name = model.Name;

			return Ok();
		}
	}
}
