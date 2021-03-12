using BloggingApp.Models;
using BloggingApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Posts post)
        {
            if (post == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            _postService.AddPosts(post);

            return Ok("Record inserted successfully");
        }

        [HttpPut("{Id}")]
        public IActionResult Put(long id, [FromBody] Posts post)
        {
            if (post == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            _postService.UpdatePosts(id, post);
            return Ok("Record Updated Successfully");
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(long id)
        {
            _postService.DeletePosts(id);
            return StatusCode(StatusCodes.Status200OK, "Record has been deleted successfully");
        }
    }
}
