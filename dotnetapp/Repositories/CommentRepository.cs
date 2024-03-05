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
using dotnetapp.Model;
using dotnetapp.Repositories;

namespace dotnetapp.Repositories
{
    public class CommentRepository 
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Comment> GetAllComments(int postId) =>
            _context.Posts
                .Where(p => p.Id == postId)
                .SelectMany(p => p.Comments)
                .ToList();

        public Comment GetComment(int id) =>
            _context.Comments.Find(id);

        public void AddComment(int postId, Comment comment)
        {
            var post = _context.Posts.Find(postId);
            if (post != null)
            {
                post.Comments.Add(comment);
                _context.SaveChanges();
            }
        }

        // public void UpdateComment(Comment comment)
        // {
        //     // var existingComment = _context.Comments.Find(comment.Id);
        // var existingComment = _context.Comments.FirstOrDefault(p => p.Id == comment.Id);
        //     if (existingComment != null)
        //     {
        //         existingComment.Text = comment.Text;
        //         _context.SaveChanges();
        //     }

        // }

public void UpdateComment(Comment comment)
{
     var existingComment = _context.Comments.Find(comment.Id);
    // var existingComment = _context.Comments.FirstOrDefault(p => p.Id == comment.Id);
        // Console.WriteLine($"Existing Comment: Id={existingComment}");

    if (existingComment != null)
    {
        // Console.WriteLine($"Existing Comment: Id={existingComment.Id}");

        // Check if comment.Text is not null before assigning it
        if (comment.Text != null)
        {
            existingComment.Text = comment.Text;
        }
        // Console.WriteLine($"Existing Comment: Id={existingComment.Id}, Text={existingComment.Text}");

        _context.SaveChanges();
    }

}


        public void SaveComment(int postId, Comment comment)
{
    var post = _context.Posts.Find(postId);
    if (post != null)
    {
        post.Comments.Add(comment);
        _context.SaveChanges();
    }
}


        public void DeleteComment(int id)
        {
            var comment = _context.Comments.Find(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
            }
        }
    }
}
