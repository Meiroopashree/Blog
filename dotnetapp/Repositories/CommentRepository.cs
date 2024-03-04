// CommentRepository.cs

using System.Collections.Generic;
using System.Linq;
// CommentRepository.cs
public class CommentRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly Dictionary<int, List<Comment>> _postComments = new Dictionary<int, List<Comment>>();

    public CommentRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Comment> GetAllComments(int postId)
    {
        if (_postComments.TryGetValue(postId, out var comments))
        {
            return comments.ToList();
        }
        return new List<Comment>();
    }

    public Comment GetComment(int commentId) => _postComments.Values.SelectMany(comments => comments).FirstOrDefault(c => c.Id == commentId);

    public void SaveComment(int postId, Comment comment)
    {
        if (!_postComments.ContainsKey(postId))
        {
            _postComments[postId] = new List<Comment>();
        }

        _postComments[postId].Add(comment);
    }

    public void UpdateComment(Comment comment)
    {
        foreach (var comments in _postComments.Values)
        {
            var existingComment = comments.FirstOrDefault(c => c.Id == comment.Id);
            if (existingComment != null)
            {
                existingComment.Text = comment.Text;
                break;
            }
        }
    }

    public void DeleteComment(int commentId)
    {
        foreach (var comments in _postComments.Values)
        {
            var comment = comments.FirstOrDefault(c => c.Id == commentId);
            if (comment != null)
            {
                comments.Remove(comment);
                break;
            }
        }
    }
}
