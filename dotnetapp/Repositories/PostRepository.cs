using System.Collections.Generic;
using System.Linq;
using dotnetapp.Model;
using Microsoft.EntityFrameworkCore;
public class PostRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PostRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Post> GetAllPosts() => _dbContext.Posts.ToList();
    //  public List<Post> GetAllPosts()
    //     {
    //         // Include comments when retrieving all posts
    //         return _dbContext.Posts.Include(p => p.Comments).ToList();
    //     }


    public Post GetPost(int id) => _dbContext.Posts.FirstOrDefault(p => p.Id == id);

    //  public Post GetPost(int id)
    //     {
    //         // Include comments when retrieving a specific post
    //         return _dbContext.Posts.Include(p => p.Comments).FirstOrDefault(p => p.Id == id);
    //     }

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
