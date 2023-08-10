namespace backend.models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public string PosterName { get; set; }
        public string Content { get; set; }
        public Comment(User user, string content, Guid postId)
        {
            Id = Guid.NewGuid();
            UserId = user.Id;
            PosterName = user.Username;
            Content = content;
            PostId = postId;
        }
        public Comment() { }
    }
}
