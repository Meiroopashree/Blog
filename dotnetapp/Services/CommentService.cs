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
using dotnetapp.Models;
using dotnetapp.Data.Repositories;

namespace dotnetapp.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
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

        public void UpdateComment(Comment comment)
        {
            _commentRepository.UpdateComment(comment);
        }

        public void DeleteComment(int id)
        {
            _commentRepository.DeleteComment(id);
        }
    }
}
