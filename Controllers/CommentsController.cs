using BloggingApp.BloggingDataContext;
using BloggingApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        BloggingDBContext _bloggingDBContext;

        public CommentsController(BloggingDBContext bloggingDBContext)
        {
            _bloggingDBContext = bloggingDBContext;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Comments comments)
        {
            if (comments == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            try
            {
                _bloggingDBContext.Comments.Add(comments);

                _bloggingDBContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public IActionResult Put(long id, [FromBody] Comments comments)
        {
            if (comments == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            try
            {
                var currentBlog = _bloggingDBContext.Comments.Find(id);

                if (currentBlog == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Record Not Found");
                }

                currentBlog.Title = comments.Title;
                currentBlog.Description = comments.Description;
                currentBlog.PostId = comments.PostId;

                _bloggingDBContext.SaveChanges();
                return Ok("Record Updated Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status304NotModified, "Error in Updating the Field");
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(long Id)
        {
            try
            {
                var commentToDelete = _bloggingDBContext.Comments.Find(Id);
                if (commentToDelete == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "No record Found");
                }

                _bloggingDBContext.Comments.Remove(commentToDelete);
                _bloggingDBContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, "Record has been deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status304NotModified, "Error in Deleting the record");
            }
        }
    }
}
