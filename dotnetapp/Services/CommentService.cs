public class CommentService : ICommentService
{
    private readonly CommentRepository _commentRepository;

    public CommentService(CommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public List<Comment> GetAllComments() => _commentRepository.GetAllComments();

    public Comment GetComment(int id) => _commentRepository.GetComment(id);

    public void SaveComment(Comment comment) => _commentRepository.SaveComment(comment);

    public void UpdateComment(Comment comment) => _commentRepository.UpdateComment(comment);

    public void DeleteComment(int id) => _commentRepository.DeleteComment(id);
}