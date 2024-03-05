// // CommentController.cs
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using System.Linq;
// using dotnetapp.Services;


// [Route("api/posts/{postId}/comments")]
// [ApiController]
// public class CommentController : ControllerBase
// {
//     private readonly ICommentService _commentService;

//     public CommentController(ICommentService commentService)
//     {
//         _commentService = commentService;
//     }

//     [HttpGet]
//     public IActionResult GetComments(int postId)
//     {
//         var comments = _commentService.GetAllComments(postId);
//         return Ok(comments);
//     }

//     [HttpGet("{commentId}")]
//     public IActionResult GetComment(int postId, int commentId)
//     {
//         var comment = _commentService.GetComment(commentId);
//         if (comment == null)
//             return NotFound();

//         return Ok(comment);
//     }

//     [HttpPost]
//     public IActionResult CreateComment(int postId, [FromBody] Comment comment)
//     {
//         if (!ModelState.IsValid)
//             return BadRequest(ModelState);

//         _commentService.SaveComment(postId, comment);
//         return Created($"/api/posts/{postId}/comments/{comment.Id}", comment);
//     }

//     [HttpPut("{commentId}")]
//     public IActionResult UpdateComment(int postId, int commentId, [FromBody] Comment updatedComment)
//     {
//         var existingComment = _commentService.GetComment(commentId);
//         if (existingComment == null)
//             return NotFound();

//         _commentService.UpdateComment(updatedComment);
//         return NoContent();
//     }

//     [HttpDelete("{commentId}")]
//     public IActionResult DeleteComment(int postId, int commentId)
//     {
//         var existingComment = _commentService.GetComment(commentId);
//         if (existingComment == null)
//             return NotFound();

//         _commentService.DeleteComment(commentId);
//         return NoContent();
//     }
// }


using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;
using dotnetapp.Services;

namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("{postId}")]
        public ActionResult<List<Comment>> GetAllComments(int postId)
        {
            var comments = _commentService.GetAllComments(postId);
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public ActionResult<Comment> GetComment(int id)
        {
            var comment = _commentService.GetComment(id);

            if (comment == null)
                return NotFound();

            return Ok(comment);
        }

        [HttpPost("{postId}")]
        public IActionResult SaveComment(int postId, [FromBody] Comment comment)
        {
            _commentService.SaveComment(postId, comment);
            return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment);
        }

        [HttpPut]
        public IActionResult UpdateComment([FromBody] Comment comment)
        {
            _commentService.UpdateComment(comment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            _commentService.DeleteComment(id);
            return NoContent();
        }
    }
}
