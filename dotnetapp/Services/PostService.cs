public class PostService : IPostService
{
    private readonly PostRepository _postRepository;

    public PostService(PostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    // public List<Post> GetAllPosts() => _postRepository.GetAllPosts();
    public List<Post> GetAllPosts()
{
    return _postRepository.GetAllPosts();
}


    public Post GetPost(int id) => _postRepository.GetPost(id);

    public void SavePost(Post post) => _postRepository.SavePost(post);

    public void UpdatePost(Post post) => _postRepository.UpdatePost(post);

    public void DeletePost(int id) => _postRepository.DeletePost(id);
}