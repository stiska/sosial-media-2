using backend.models;
using System.Data.SqlTypes;
using System;
using System.ComponentModel.Design;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data.SqlClient;
using Dapper;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
const string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SomeDB;Integrated Security=True;";

var users = new List<User>
{
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

app.MapGet("/api/User/{id}", async (Guid id) =>
{
    var conn = new SqlConnection(connStr);
    const string sql = "SELECT Id, FirstName, LastName, Username FROM Users WHERE Id = @Id";
    var currentUser = await conn.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
    return currentUser;
});

app.MapGet("/api/Users/{id}", async (Guid id) =>
{
    var conn = new SqlConnection(connStr);
    const string sql = "SELECT Id, FirstName, LastName, Username FROM Users WHERE Id != @Id";
    var users = await conn.QueryAsync<User>(sql, new { Id = id });
    return users;
});

app.MapPost("/api/AddFriend", async (AddFriend ids) =>
{
 
    var conn = new SqlConnection(connStr);
    if (ids.FriendId != ids.UserId)
    {
        const string sql = "INSERT Friends (UserId, FriendId) VALUES (@UserId, @FriendId);";
        var rowsAffected = await conn.ExecuteAsync(sql, ids);
        const string sql2 = "INSERT Friends (UserId, FriendId) VALUES (@FriendId, @UserId);";
        rowsAffected += await conn.ExecuteAsync(sql2, ids);
        return rowsAffected;
    }
    else return 0;
});

app.MapGet("/api/FriendsList/{id}", async (Guid id) =>
{
    var conn = new SqlConnection(connStr);
    const string sql = "SELECT FriendId FROM Friends WHERE UserId = @Id";
    var friendsId = await conn.QueryAsync<Guid>(sql, new { Id = id });
    var friends = new List<User>();

    foreach (var friendId in friendsId)
    {
        const string sql2 = "SELECT Id, FirstName, LastName, Username FROM Users WHERE Id = @Id";
        var user = await conn.QueryFirstOrDefaultAsync<User>(sql2, new { Id = friendId });

        if (user != null)
        {
            friends.Add(user);
        }
    }

    return friends;
});

app.MapPost("/api/Addpost", async (PostResponse postResponse) =>
{
    var conn = new SqlConnection(connStr);
    const string sql = "SELECT Id, FirstName, LastName, Username FROM Users WHERE Id = @Id";
    var user = await conn.QueryFirstOrDefaultAsync<User>(sql, new { Id = postResponse.UserId });
    var post = new Posts(user, postResponse.Content);
    const string sql2 = "INSERT Posts (Id, UserId, [Content]) VALUES (@Id, @UserId, @Content);";
    var rowsAffected = await conn.ExecuteAsync(sql2, post);
    return rowsAffected;
});

app.MapGet("/api/Posts", () =>
{
    return posts;
});

app.MapGet("/api/Comments/{id}", (Guid id) =>
{
    Posts targetPost = posts.SingleOrDefault(item => item.Id == id);
    return targetPost.Comments;
});

app.MapPost("/api/AddComment", (Comment comment) =>
{
    var target = posts.SingleOrDefault(item => item.Id == comment.PostId);
    target.Comments.Add(new Comment(comment.UserId, comment.PosterName, comment.Content, comment.PostId));
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
app.MapPost("/api/AddMesage", (Message comment) =>
{
    Chat targetChat = chats.SingleOrDefault(item => item.Id == comment.ChatId);
    targetChat.Messages.Add(new Message(comment.Content, comment.UserId, comment.ChatId));
});

app.MapGet("/api/Mesages/{id}", (Guid id) =>
{
   Chat targetChat = chats.SingleOrDefault(item => item.Id == id);
    return targetChat.Messages;
});



app.Run();