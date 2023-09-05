namespace backend.models
{
    public class PostResponse
    {
        public Guid UserId { get; set; }
        public string Content { get; set; }

        public PostResponse(Guid id, string content)
        {
            UserId = id;
            Content = content;
        }
        public PostResponse() { }
    }
}
