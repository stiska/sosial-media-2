namespace backend.models
{
    public class Chat
    {
        public Guid Id { get; set; }
        public List<Guid> Paricipants { get; set; }
        public List<Message> Messages { get; set; }
        public Chat(string test) 
        { 
            Id = Guid.NewGuid();
            Paricipants = new List<Guid>();
            Messages = new List<Message>();
        }
        public Chat() { }
    }
}
