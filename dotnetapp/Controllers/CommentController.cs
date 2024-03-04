// CommentController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

[Route("api/posts/{postId}/comments")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly CommentRepository _commentRepository;

    public CommentController(CommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    [HttpGet]
    public IActionResult GetComments(int postId)
    {
        var comments = _commentRepository.GetAllComments(postId);
        return Ok(comments); // 200 OK
    }

    [HttpGet("{commentId}")]
    public IActionResult GetComment(int postId, int commentId)
    {
        var comment = _commentRepository.GetComment(commentId);
        if (comment == null)
            return NotFound(); // 404 Not Found

        return Ok(comment); // 200 OK
    }

    [HttpPost]
    public IActionResult CreateComment(int postId, [FromBody] Comment comment)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState); // 400 Bad Request

        comment.PostId = postId; // Associate comment with the post
        _commentRepository.SaveComment(comment);
        return Created($"/api/posts/{postId}/comments/{comment.Id}", comment); // 201 Created
    }

    [HttpPut("{commentId}")]
    public IActionResult UpdateComment(int postId, int commentId, [FromBody] Comment updatedComment)
    {
        var existingComment = _commentRepository.GetComment(commentId);
        if (existingComment == null)
            return NotFound(); // 404 Not Found

        existingComment.Text = updatedComment.Text;
        _commentRepository.UpdateComment(existingComment);
        return NoContent(); // 204 No Content
    }

    [HttpDelete("{commentId}")]
    public IActionResult DeleteComment(int postId, int commentId)
    {
        var existingComment = _commentRepository.GetComment(commentId);
        if (existingComment == null)
            return NotFound(); // 404 Not Found

        _commentRepository.DeleteComment(commentId);
        return NoContent(); // 204 No Content
    }
}
