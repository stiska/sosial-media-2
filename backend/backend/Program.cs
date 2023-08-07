using backend.models;

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

app.MapGet("/api/test", () =>
{
    return new User("Stian","Skatvedt");
});
app.MapGet("/api/FriendsList", () =>
{
    return inmemoryDb;
});

app.Run();