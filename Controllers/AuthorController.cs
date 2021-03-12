using BloggingApp.BloggingDataContext;
using BloggingApp.Models;
using BloggingApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BloggingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Author author)
        {
            if (author == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            _authorService.AddAuthor(author);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{Id}")]
        public IActionResult Put(long id, [FromBody] Author author)
        {
            if (author == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            _authorService.UpdateAuthor(id, author);
            return Ok("Record Updated Successfully");
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(long id)
        {
            _authorService.DeleteAuthor(id);
            return StatusCode(StatusCodes.Status200OK, "Record has been deleted successfully");
        }
    }
}
