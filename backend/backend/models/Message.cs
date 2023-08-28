namespace backend.models
{
    public class Message
    {
        public Guid Id { get; set; }
        public Guid ChatId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }

        public Message(string content,Guid userId, Guid chatId) 
        {
            Id = Guid.NewGuid();
            ChatId = chatId;
            Content = content;
            UserId = userId;
        }
        public Message() { }
    }
}
