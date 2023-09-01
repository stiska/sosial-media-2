namespace backend.models
{
    public class AddFriend
    {
        public Guid UserId { get; set; }
        public Guid FriendId { get; set; }
    public AddFriend(Guid user, Guid friend) 
    {
        UserId = user;
        FriendId = friend;
    }
    public AddFriend() { }
    }
}
