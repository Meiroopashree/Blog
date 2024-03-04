public class PostRepository
{
    private readonly List<Post> _posts = new List<Post>();

    public List<Post> GetAllPosts() => _posts;

    public Post GetPost(int id) => _posts.FirstOrDefault(p => p.Id == id);

    public void SavePost(Post post) => _posts.Add(post);

    public void UpdatePost(Post post) { /* Implement update logic */ }

    public void DeletePost(int id) => _posts.RemoveAll(p => p.Id == id);
}