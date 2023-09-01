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