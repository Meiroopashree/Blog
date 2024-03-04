// CommentController.cs

using Microsoft.AspNetCore.Mvc;

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
    public IActionResult GetComments(int postId)
    {
        var comments = _commentService.GetAllComments();
        return Ok(comments); // 200 OK
    }

    [HttpGet("{commentId}")]
    public IActionResult GetComment(int postId, int commentId)
    {
        var comment = _commentService.GetComment(commentId);
        if (comment == null)
            return NotFound(); // 404 Not Found

        return Ok(comment); // 200 OK
    }

    [HttpPost]
    public IActionResult CreateComment(int postId, [FromBody] Comment comment)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState); // 400 Bad Request

        _commentService.SaveComment(comment);
        return Created($"/api/posts/{postId}/comments/{comment.Id}", comment); // 201 Created
    }

    [HttpPut("{commentId}")]
    public IActionResult UpdateComment(int postId, int commentId, [FromBody] Comment comment)
    {
        var existingComment = _commentService.GetComment(commentId);
        if (existingComment == null)
            return NotFound(); // 404 Not Found

        _commentService.UpdateComment(comment);
        return NoContent(); // 204 No Content
    }

    [HttpDelete("{commentId}")]
    public IActionResult DeleteComment(int postId, int commentId)
    {
        var existingComment = _commentService.GetComment(commentId);
        if (existingComment == null)
            return NotFound(); // 404 Not Found

        _commentService.DeleteComment(commentId);
        return NoContent(); // 204 No Content
    }
}