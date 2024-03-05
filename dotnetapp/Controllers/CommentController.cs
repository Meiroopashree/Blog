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

// CommentController.cs
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Model;
using dotnetapp.Services;

[Route("api/posts/{postId}/comments")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet]
    public IActionResult GetAllComments(int postId)
    {
        var comments = _commentService.GetAllComments(postId);
        return Ok(comments);
    }

    [HttpGet("{commentId}")]
    public IActionResult GetComment(int postId, int commentId)
    {
        var comment = _commentService.GetComment(commentId);
        if (comment == null)
            return NotFound();

        return Ok(comment);
    }

    [HttpPost]
    public IActionResult AddComment(int postId, [FromBody] Comment comment)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _commentService.SaveComment(postId, comment);
        return Created($"/api/posts/{postId}/comments/{comment.Id}", comment);
    }

    // [HttpPut("{commentId}")]
    // public IActionResult UpdateComment(int postId, int commentId, [FromBody] Comment updatedComment)
    // {
    //     var existingComment = _commentService.GetComment(commentId);
    //     if (existingComment == null)
    //         return NotFound();

    //     _commentService.UpdateComment(updatedComment);
    //     return NoContent();
    // }


    
    [HttpPut("{commentId}")]
    public IActionResult UpdateComment(int postId, int commentId, [FromBody] Comment updatedComment)
    {
        Console.WriteLine(postId);
        var existingComment = _commentService.GetComment(commentId);
        Console.WriteLine(existingComment);
        if (existingComment == null)
            return NotFound();

        _commentService.UpdateComment(updatedComment);
        return NoContent();
    }

    [HttpDelete("{commentId}")]
    public IActionResult DeleteComment(int postId, int commentId)
    {
        var existingComment = _commentService.GetComment(commentId);
        if (existingComment == null)
            return NotFound();

        _commentService.DeleteComment(commentId);
        return NoContent();
    }
}
