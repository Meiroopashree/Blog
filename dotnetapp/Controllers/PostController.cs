using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using dotnetapp.Model;

namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PostController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult AddPost([FromBody] Post post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();

            return Ok(post);
        }

        [HttpGet]
        public IActionResult GetAllPosts()
        {
            var posts = _dbContext.Posts
            .Include(p => p.Comments)
            .ToList();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public IActionResult GetPost(int id)
        {
            // var post = _dbContext.Posts.FirstOrDefault(p => p.Id == id);

            // if (post == null)
            //     return NotFound();

            // return Ok(post);

             var post = _dbContext.Posts.Include(p => p.Comments).FirstOrDefault(p => p.Id == id);
             return Ok(post);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Post updatedPost)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingPost = _dbContext.Posts.FirstOrDefault(p => p.Id == id);

            if (existingPost == null)
                return NotFound();

            existingPost.Title = updatedPost.Title;
            existingPost.Content = updatedPost.Content;

            _dbContext.SaveChanges();

            return Ok(existingPost);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            var post = _dbContext.Posts.FirstOrDefault(p => p.Id == id);

            if (post == null)
                return NotFound();

            _dbContext.Posts.Remove(post);
            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
