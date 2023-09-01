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

app.MapGet("/api/User", async() =>
{
    var conn = new SqlConnection(connStr);
    const string sql = "SELECT Id, FirstName, LastName, Username FROM Users WHERE Id = '290ee2b9-3277-46cf-9320-7674b06b670d'";
    var currentUser = await conn.QueryAsync<User>(sql);
    return currentUser.SingleOrDefault(item => item.Id != null) ;
});

app.MapGet("/api/Users", async () =>
{
    var conn = new SqlConnection(connStr);
    const string sql = "SELECT Id, FirstName, LastName, Username FROM Users WHERE Id != '290ee2b9-3277-46cf-9320-7674b06b670d'";
    var users = await conn.QueryAsync<User>(sql);
    return users;
});

app.MapPost("/api/AddFriend", async (AddFriend ids) =>
{
    var conn = new SqlConnection(connStr);
    const string sql = "INSERT Friends (UserId, FriendId) VALUES (@UserId, @FriendId);";
    var rowsAffected = await conn.ExecuteAsync(sql, ids);
    const string sql2 = "INSERT Friends (UserId, FriendId) VALUES (@FriendId, @UserId);";
    rowsAffected += await conn.ExecuteAsync(sql2, ids);
    return rowsAffected;
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
    var target = posts.SingleOrDefault(item => item.Id == comment.PostId);
    target.Comments.Add(new Comment(comment.UserId, comment.PosterName, comment.Content, comment.PostId));   
});

app.Run();