public class CommentRepository
{
    private readonly List<Comment> _comments = new List<Comment>();

    public List<Comment> GetAllComments() => _comments;

    public Comment GetComment(int id) => _comments.FirstOrDefault(c => c.Id == id);

    public void SaveComment(Comment comment) => _comments.Add(comment);

    public void UpdateComment(Comment comment) { /* Implement update logic */ }

    public void DeleteComment(int id) => _comments.RemoveAll(c => c.Id == id);
}