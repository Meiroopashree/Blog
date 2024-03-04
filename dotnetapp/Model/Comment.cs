public class Comment
{
    public int Id { get; set; }
    public string Text { get; set; }
    public Post Post { get; set; }
}