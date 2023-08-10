namespace backend.models
{
    public class CommentResponse
    {
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public Guid PostId { get; set; }
        
        public CommentResponse(Guid userid, string content, Guid postId)
        {
            UserId = userid;
            Content = content;
            PostId = postId;
        }
        public CommentResponse() { }
    }
}
