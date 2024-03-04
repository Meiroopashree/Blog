// ICommentService.cs
using System.Collections.Generic;

namespace dotnetapp.Services
{
    public interface ICommentService
    {
        List<Comment> GetAllComments(int postId);
        Comment GetComment(int id);
        void SaveComment(int postId, Comment comment);
        void UpdateComment(Comment comment);
        void DeleteComment(int id);
    }
}
