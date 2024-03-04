// CommentRepository.cs

using System.Collections.Generic;
using System.Linq;

using dotnetapp.Model;


public class CommentRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CommentRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Comment> GetAllComments(int postId) => _dbContext.Comments.Where(c => c.PostId == postId).ToList();

    public Comment GetComment(int id) => _dbContext.Comments.FirstOrDefault(c => c.Id == id);

    public void SaveComment(int postId, Comment comment)
    {
        comment.PostId = postId;
        _dbContext.Comments.Add(comment);
        _dbContext.SaveChanges();
    }

    public void UpdateComment(Comment comment)
    {
        var existingComment = _dbContext.Comments.FirstOrDefault(c => c.Id == comment.Id);

        if (existingComment != null)
        {
            existingComment.Text = comment.Text;
            _dbContext.SaveChanges();
        }
    }

    public void DeleteComment(int id)
    {
        var comment = _dbContext.Comments.FirstOrDefault(c => c.Id == id);

        if (comment != null)
        {
            _dbContext.Comments.Remove(comment);
            _dbContext.SaveChanges();
        }
    }
}
