using Microsoft.Extensions.Caching.Memory;

namespace backend.models
{
    public class Posts
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string PosterName { get; set; }
        public string Content { get; set; }

        public Posts( User user, string content)
        {
            Id = Guid.NewGuid();
            UserId = user.Id;
            PosterName = user.Username;
            Content = content;
        }
        public Posts() { }
    }
}
