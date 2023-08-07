
using backend.models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var inmemoryDb = new List<int>
{
    1,2,3,4,5
};

app.MapGet("/api/test", () =>
{
    return new User("Stian","Skatvedt");
});

app.Run();