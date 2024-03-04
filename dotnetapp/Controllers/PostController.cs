// PostController.cs
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Data;
using dotnetapp.Models;

[Route("api/posts")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    public IActionResult GetPosts()
    {
        var posts = _postService.GetAllPosts();
        return Ok(posts); // 200 OK
    }

    [HttpGet("{id}")]
    public IActionResult GetPost(int id)
    {
        var post = _postService.GetPost(id);
        if (post == null)
            return NotFound(); // 404 Not Found

        return Ok(post); // 200 OK
    }

    [HttpPost]
    public IActionResult CreatePost([FromBody] Post post)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState); // 400 Bad Request

        _postService.SavePost(post);
        return Created($"/api/posts/{post.Id}", post); // 201 Created
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePost(int id, [FromBody] Post post)
    {
        var existingPost = _postService.GetPost(id);
        if (existingPost == null)
            return NotFound(); // 404 Not Found

        _postService.UpdatePost(post);
        return NoContent(); // 204 No Content
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePost(int id)
    {
        var existingPost = _postService.GetPost(id);
        if (existingPost == null)
            return NotFound(); // 404 Not Found

        _postService.DeletePost(id);
        return NoContent(); // 204 No Content
    }
}