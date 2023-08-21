using backend.models;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var users = new List<User>
{
    new User("John", "Doe"),
    new User("Jane", "Smith"),
    new User("Michael", "Johnson"),
    new User("Emily", "Williams"),
    new User("David", "Brown"),
    new User("Sarah", "Jones"),
    new User("Robert", "Garcia"),
    new User("Jennifer", "Martinez"),
    new User("William", "Davis"),
    new User("Linda", "Rodriguez"),
    new User("James", "Miller"),
    new User("Richard", "Gonzalez"),
    new User("Mary", "Lopez"),
    new User("Charles", "Lee"),
    new User("Patricia", "Hernandez"),
    new User("Matthew", "Clark"),
    new User("Elizabeth", "Lewis"),
    new User("Joseph", "Taylor"),
    new User("Barbara", "Gomez"),
    new User("Daniel", "Hernandez"),
    new User("Susan", "Young"),
    new User("Paul", "Scott"),
};
var chats = new List<Chat>
{
    new Chat("")
};
var posts = new List<Posts>
{
    new Posts(users[2], "Hvordan få bedre søvn for bedre mental helse: " +
    "Søvn spiller en viktig rolle i vår mentale helse," +
    " og å forbedre søvnkvaliteten kan ha en positiv innvirkning på humør," +
    " stressnivå og energinivå i løpet av dagen. Dette kan inkludere å opprettholde en jevn søvnplan," +
    " skape et behagelig sovemiljø og redusere bruk av elektroniske enheter før sengetid." +
    " Unngå koffein og alkohol før sengetid:" +
    "Vær oppmerksom på skjermtid: Skjermene fra mobiltelefoner,"),

    new Posts(users[3], "Hvordan få bedre søvn for bedre mental helse: " +
    "Søvn spiller en viktig rolle i vår mentale helse," +
    " og å forbedre søvnkvaliteten kan ha en positiv innvirkning på humør," +
    " for å sikre at du får en god natts søvn." +
    "Prøv avslapningsteknikker: Avslapningsteknikker som yoga," +
    " meditasjon eller dyp pusting kan hjelpe deg med å roe ned før sengetid og forbedre søvnkvaliteten." +
    " Prøv å inkludere disse teknikkene i din daglige rutine for å redusere stress og angst." +
    "Vær oppmerksom på skjermtid: Skjermene fra mobiltelefoner,"),
};

app.MapGet("/api/test", () =>
{
    return users[0];
});

app.MapGet("/api/Posts", () =>
{
    return posts;
});

app.MapPost("/api/Chat", (ChatIdResponse chatIdResponse) =>
{
    var target = chats.SingleOrDefault(item => item.Paricipants.Contains(chatIdResponse.CurrentId) && 
    item.Paricipants.Contains(chatIdResponse.FriendId));
    if (target == null)
    {
        Chat chat = new Chat("");
        chat.Paricipants.Add(chatIdResponse.CurrentId);
        chat.Paricipants.Add(chatIdResponse.FriendId);
        chats.Add(chat);
        target = chat;
    }
    return target;
});

app.MapGet("/api/FriendsList", () =>
{
    return users;
});

app.MapGet("/api/Comments/{id}", (Guid id) =>
{
    Posts targetPost = posts.SingleOrDefault(item => item.Id == id);
    return targetPost.Comments;
});

app.MapPost("/api/AddComment", (Comment comment) =>
{
    var current = posts.Count();
    var target = posts.SingleOrDefault(item => item.Id == comment.PostId);
    target.Comments.Add(new Comment(comment.UserId, comment.PosterName, comment.Content, comment.PostId));
    if (current == posts.Count()) { return "noe gikk galt"; }
    else { return "yipi"; }
});

app.Run();