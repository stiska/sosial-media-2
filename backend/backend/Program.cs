using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var inmemoryDb = new List<int>
{
    1,2,3,4,5
};

app.MapGet("/api/test", () =>
{
    return inmemoryDb;
});

app.Run();