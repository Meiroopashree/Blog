using System.Collections.Generic;
using System.Linq;

public class PostRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PostRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Post> GetAllPosts() => _dbContext.Posts.ToList();

    public Post GetPost(int id) => _dbContext.Posts.FirstOrDefault(p => p.Id == id);

    public void SavePost(Post post)
    {
        _dbContext.Posts.Add(post);
        _dbContext.SaveChanges();
    }

    public void UpdatePost(Post post)
    {
        // Assuming Post has an Id property
        var existingPost = _dbContext.Posts.FirstOrDefault(p => p.Id == post.Id);

        if (existingPost != null)
        {
            existingPost.Title = post.Title;
            existingPost.Content = post.Content;
            _dbContext.SaveChanges();
        }
    }

    public void DeletePost(int id)
    {
        var post = _dbContext.Posts.FirstOrDefault(p => p.Id == id);

        if (post != null)
        {
            _dbContext.Posts.Remove(post);
            _dbContext.SaveChanges();
        }
    }
}
