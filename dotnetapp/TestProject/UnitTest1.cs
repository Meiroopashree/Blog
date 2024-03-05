using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using dotnetapp.Controllers;
using dotnetapp.Model;
using System.Collections.Generic;
using dotnetapp.Services;

namespace dotnetapp.Tests
{
    [TestFixture]
    public class BlogControllerTests
    {
        private PostController _bcontroller;
        private IPostService _PostService;
        private CommentController _ocontroller;
        private ICommentService _orderService;

        [SetUp]
        public void Setup()
        {
            _PostService = new PostService(new PostRepository());
            _bcontroller = new PostController(_PostService);
            _orderService = new CommentService(new CommentRepository());
            _ocontroller = new CommentController(_orderService);
        }

        [Test]
        public void GetAllPosts_ReturnsOk()
        {
            // Arrange

            // Act
            var result = _bcontroller.GetAllPosts() as ActionResult<List<Post>>;
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public void GetPost_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            int nonExistingPostId = 999;

            // Act
            var result = _bcontroller.GetPost(nonExistingPostId) as ActionResult<Post>;
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NotFoundResult>(result.Result);
        }

        [Test]
        public void AddPost_ValidData_ReturnsOk()
        {
            // Arrange
            var newPost = new Post
            {
                Id = 2,
                Title = "New Post",
                Content = "Fiction"
            };

            // Act
            var result = _bcontroller.AddPost(newPost) as ActionResult<Post>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public void DeletePost_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            int nonExistingPostId = 999;

            // Act
            var result = _bcontroller.DeletePost(nonExistingPostId) as IActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
        [Test]
        public void GetAllComments_ReturnsOk()
        {
            // Arrange

            // Act
            var result = _ocontroller.GetAllComments() as ActionResult<List<Comment>>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public void GetComment_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            int nonExistingCommentId = 999;

            // Act
            var result = _ocontroller.GetComment(nonExistingCommentId) as ActionResult<Comment>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NotFoundResult>(result.Result);
        }

        [Test]
        public void AddComment_ValidData_ReturnsOk()
        {
            // Arrange
            var newComment = new Comment
            {
                Id = 2,
                Text = "John Doe Comment"
            };

            // Act
            var result = _ocontroller.AddComment(newComment) as ActionResult<Comment>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public void DeleteComment_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            int nonExistingCommentId = 999;

            // Act
            var result = _ocontroller.DeleteComment(nonExistingCommentId) as IActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
    }
}
