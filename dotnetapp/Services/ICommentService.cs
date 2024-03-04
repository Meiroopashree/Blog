public interface ICommentService
{
    List<Comment> GetAllComments();
    Comment GetComment(int id);
    void SaveComment(Comment comment);
    void UpdateComment(Comment comment);
    void DeleteComment(int id);
}