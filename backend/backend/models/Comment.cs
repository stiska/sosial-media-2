namespace backend.models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public string PosterName { get; set; }
        public string Content { get; set; }
        public Comment(Guid userId, string username, string content, Guid postId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            PosterName = username;
            Content = content;
            PostId = postId;
        }
        public Comment() { }
    }
}
