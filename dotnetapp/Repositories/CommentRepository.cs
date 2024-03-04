// CommentRepository.cs

using System.Collections.Generic;
using System.Linq;
public class CommentRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CommentRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Comment> GetAllComments(int postId) => _dbContext.Comments.Where(c => c.PostId == postId).ToList();

    public Comment GetComment(int commentId) => _dbContext.Comments.FirstOrDefault(c => c.Id == commentId);

    public void SaveComment(Comment comment)
    {
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

    public void DeleteComment(int commentId)
    {
        var comment = _dbContext.Comments.FirstOrDefault(c => c.Id == commentId);

        if (comment != null)
        {
            _dbContext.Comments.Remove(comment);
            _dbContext.SaveChanges();
        }
    }
}
