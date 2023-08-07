using backend.models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var inmemoryDb = new List<User>
{
    new User("Nei","Takk"),
    new User("Vil","Ikke"),
    new User("Skjer","Ikke"),
    new User("Ellers","Takk")
};

app.MapGet("/api/test", () =>
{
    return new User("Stian","Skatvedt");
});
app.MapGet("/api/FriendsList", () =>
{
    return inmemoryDb;
});

app.Run();