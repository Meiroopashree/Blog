// // CommentRepository.cs

// using System.Collections.Generic;
// using System.Linq;

// using dotnetapp.Model;

// public class CommentRepository
// {
//     private readonly ApplicationDbContext _dbContext;

//     public CommentRepository(ApplicationDbContext dbContext)
//     {
//         _dbContext = dbContext;
//     }

//     public List<Comment> GetAllComments(int postId) => _dbContext.Comments.Where(c => c.PostId == postId).ToList();

//     public Comment GetComment(int id) => _dbContext.Comments.FirstOrDefault(c => c.Id == id);

//     public void SaveComment(int postId, Comment comment)
//     {
//         comment.PostId = postId;
//         _dbContext.Comments.Add(comment);
//         _dbContext.SaveChanges();
//     }

//     public void UpdateComment(Comment comment)
//     {
//         var existingComment = _dbContext.Comments.FirstOrDefault(c => c.Id == comment.Id);

//         if (existingComment != null)
//         {
//             existingComment.Text = comment.Text;
//             _dbContext.SaveChanges();
//         }
//     }

//     public void DeleteComment(int id)
//     {
//         var comment = _dbContext.Comments.FirstOrDefault(c => c.Id == id);

//         if (comment != null)
//         {
//             _dbContext.Comments.Remove(comment);
//             _dbContext.SaveChanges();
//         }
//     }
// }



using System.Collections.Generic;
using System.Linq;
using dotnetapp.Models;
using dotnetapp.Data;

namespace dotnetapp.Data.Repositories
{
    public class CommentRepository : ICommentService
    {
        private readonly ApplicationDbContext _dbContext;

        public CommentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Comment> GetAllComments(int postId)
        {
            // Assuming Comment has a navigation property Post
            return _dbContext.Comments.Where(c => c.Post.Id == postId).ToList();
        }

        public Comment GetComment(int id)
        {
            return _dbContext.Comments.FirstOrDefault(c => c.Id == id);
        }

        public void SaveComment(int postId, Comment comment)
        {
            // Assuming Comment has a navigation property Post
            comment.Post = _dbContext.Posts.FirstOrDefault(p => p.Id == postId);
            
            // Additional logic if Comment.Post is nullable and needs to be handled

            _dbContext.Comments.Add(comment);
            _dbContext.SaveChanges();
        }

        public void UpdateComment(Comment comment)
        {
            // Assuming Comment has an Id property
            var existingComment = _dbContext.Comments.FirstOrDefault(c => c.Id == comment.Id);

            if (existingComment != null)
            {
                existingComment.Text = comment.Text;
                // Additional properties can be updated similarly
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
}
