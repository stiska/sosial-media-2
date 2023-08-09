namespace backend.models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public List<User> FriendsList { get; set; }
        public List<Posts> PostsList { get; set; }

        public User(string firstName, string lastName)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Username = firstName + " " + lastName;
            FriendsList = new List<User>();
        }
        public User() { }
    }
}
