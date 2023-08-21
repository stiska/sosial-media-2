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
    new Posts(users[2], "Hvordan f� bedre s�vn for bedre mental helse: " +
    "S�vn spiller en viktig rolle i v�r mentale helse," +
    " og � forbedre s�vnkvaliteten kan ha en positiv innvirkning p� hum�r," +
    " stressniv� og energiniv� i l�pet av dagen. Dette kan inkludere � opprettholde en jevn s�vnplan," +
    " skape et behagelig sovemilj� og redusere bruk av elektroniske enheter f�r sengetid." +
    " Unng� koffein og alkohol f�r sengetid:" +
    "V�r oppmerksom p� skjermtid: Skjermene fra mobiltelefoner,"),

    new Posts(users[3], "Hvordan f� bedre s�vn for bedre mental helse: " +
    "S�vn spiller en viktig rolle i v�r mentale helse," +
    " og � forbedre s�vnkvaliteten kan ha en positiv innvirkning p� hum�r," +
    " for � sikre at du f�r en god natts s�vn." +
    "Pr�v avslapningsteknikker: Avslapningsteknikker som yoga," +
    " meditasjon eller dyp pusting kan hjelpe deg med � roe ned f�r sengetid og forbedre s�vnkvaliteten." +
    " Pr�v � inkludere disse teknikkene i din daglige rutine for � redusere stress og angst." +
    "V�r oppmerksom p� skjermtid: Skjermene fra mobiltelefoner,"),
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