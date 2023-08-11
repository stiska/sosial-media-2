using backend.models;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var inmemoryDb = new List<User>
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
    new User("Jessica", "Adams"),
    new User("Andrew", "Green"),
    new User("Mark", "Baker"),
    new User("Nancy", "Turner"),
    new User("Steven", "Perez"),
    new User("Laura", "Sanchez")
};
var posts = new List<Posts>
{
    new Posts(inmemoryDb[2], "Hvordan få bedre søvn for bedre mental helse: " +
    "Søvn spiller en viktig rolle i vår mentale helse," +
    " og å forbedre søvnkvaliteten kan ha en positiv innvirkning på humør," +
    " stressnivå og energinivå i løpet av dagen. Dette kan inkludere å opprettholde en jevn søvnplan," +
    " skape et behagelig sovemiljø og redusere bruk av elektroniske enheter før sengetid." +
    " Unngå koffein og alkohol før sengetid:" +
    
    "Vær oppmerksom på skjermtid: Skjermene fra mobiltelefoner,"),
    new Posts(inmemoryDb[3], "Hvordan få bedre søvn for bedre mental helse: " +
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
    return inmemoryDb[0];
});

app.MapGet("/api/Posts", () =>
{
    return posts;
});

app.MapGet("/api/FriendsList", () =>
{
    return inmemoryDb;
});

app.MapGet("/api/Comments/{id}", (Guid id) =>
{
    Posts targetPost = posts.SingleOrDefault(item => item.Id == id);
    return targetPost.Comments;
});

app.MapPost("/api/AddComment", (Comment comment) =>
{
    // get post by id get user by id post.comment.add(new comment(user,content))
    var current = posts.Count();
    var target = posts.SingleOrDefault(item => item.Id == comment.PostId);
    target.Comments.Add(new Comment(comment.UserId, comment.PosterName, comment.Content, comment.PostId));
    if (current == posts.Count()) { return "noe gikk galt"; }
    else { return "yipi"; }
});

app.Run();