namespace backend.models
{
    public class Posts
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }

        public Posts( User user, string content)
        {
            Id = Guid.NewGuid();
            UserId = user.Id;
            Content = content;
        }
        public Posts() { }
    }
}
