namespace backend.models
{
    public class ChatIdResponse
    {
        public Guid CurrentId { get; set; }
        public Guid FriendId { get; set; }

        public ChatIdResponse(Guid currentId,Guid friendId) 
        { 
            CurrentId = currentId;
            FriendId = friendId;
        }
        public ChatIdResponse() { }
    }
}
