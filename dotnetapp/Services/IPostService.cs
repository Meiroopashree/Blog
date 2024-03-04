public interface IPostService
{
    List<Post> GetAllPosts();
    Post GetPost(int id);
    void SavePost(Post post);
    void UpdatePost(Post post);
    void DeletePost(int id);
}