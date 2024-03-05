// // CommentService.cs
// using System.Collections.Generic;

// namespace dotnetapp.Services
// {
//     public class CommentService : ICommentService
//     {
//         private readonly CommentRepository _commentRepository;

//         public CommentService(CommentRepository commentRepository)
//         {
//             _commentRepository = commentRepository;
//         }

//         public List<Comment> GetAllComments(int postId) => _commentRepository.GetAllComments(postId);

//         public Comment GetComment(int id) => _commentRepository.GetComment(id);

//         public void SaveComment(int postId, Comment comment) => _commentRepository.SaveComment(postId, comment);

//         public void UpdateComment(Comment comment) => _commentRepository.UpdateComment(comment);

//         public void DeleteComment(int id) => _commentRepository.DeleteComment(id);
//     }
// }



using System.Collections.Generic;
using dotnetapp.Model;
using dotnetapp.Repositories;

namespace dotnetapp.Services
{
    public class CommentService : ICommentService
    {
        private readonly CommentRepository _commentRepository;

        public CommentService(CommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public List<Comment> GetAllComments(int postId)
        {
            return _commentRepository.GetAllComments(postId);
        }

        public Comment GetComment(int id)
        {
            return _commentRepository.GetComment(id);
        }

        public void SaveComment(int postId, Comment comment)
        {
            _commentRepository.SaveComment(postId, comment);
        }

        // public void UpdateComment(Comment comment)
        // {
        //     _commentRepository.UpdateComment(comment);
        // }
        public Comment UpdateComment(int commentId, Comment updatedComment)
    {
        var existingComment = _commentRepository.GetComment(commentId);

        if (existingComment == null)
            return null;

        existingComment.Text = updatedComment.Text;
        _commentRepository.UpdateComment(existingComment);

        return existingComment;
    }

        public void DeleteComment(int id)
        {
            _commentRepository.DeleteComment(id);
        }
    }
}
