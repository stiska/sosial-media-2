using backend.models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var inmemoryDb = new List<User>
{
    new User("Stian","Skatvedt"),
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
    new Posts(inmemoryDb[2], "Hvordan f� bedre s�vn for bedre mental helse: " +
    "S�vn spiller en viktig rolle i v�r mentale helse," +
    " og � forbedre s�vnkvaliteten kan ha en positiv innvirkning p� hum�r," +
    " stressniv� og energiniv� i l�pet av dagen. Dette kan inkludere � opprettholde en jevn s�vnplan," +
    " skape et behagelig sovemilj� og redusere bruk av elektroniske enheter f�r sengetid." +
    " Unng� koffein og alkohol f�r sengetid:" +
    " Koffein og alkohol kan forstyrre s�vnm�nstre og f�re til d�rligere s�vnkvalitet." +
    " Pr�v � begrense inntaket av koffein og alkohol, spesielt i timene f�r sengetid," +
    " for � sikre at du f�r en god natts s�vn." +
    "Pr�v avslapningsteknikker: Avslapningsteknikker som yoga," +
    " meditasjon eller dyp pusting kan hjelpe deg med � roe ned f�r sengetid og forbedre s�vnkvaliteten." +
    " Pr�v � inkludere disse teknikkene i din daglige rutine for � redusere stress og angst." +
    "V�r oppmerksom p� skjermtid: Skjermene fra mobiltelefoner,"),
    new Posts(inmemoryDb[3], "Hvordan f� bedre s�vn for bedre mental helse: " +
    "S�vn spiller en viktig rolle i v�r mentale helse," +
    " og � forbedre s�vnkvaliteten kan ha en positiv innvirkning p� hum�r," +
    " stressniv� og energiniv� i l�pet av dagen. Dette kan inkludere � opprettholde en jevn s�vnplan," +
    " skape et behagelig sovemilj� og redusere bruk av elektroniske enheter f�r sengetid." +
    " Unng� koffein og alkohol f�r sengetid:" +
    " Koffein og alkohol kan forstyrre s�vnm�nstre og f�re til d�rligere s�vnkvalitet." +
    " Pr�v � begrense inntaket av koffein og alkohol, spesielt i timene f�r sengetid," +
    " for � sikre at du f�r en god natts s�vn." +
    "Pr�v avslapningsteknikker: Avslapningsteknikker som yoga," +
    " meditasjon eller dyp pusting kan hjelpe deg med � roe ned f�r sengetid og forbedre s�vnkvaliteten." +
    " Pr�v � inkludere disse teknikkene i din daglige rutine for � redusere stress og angst." +
    "V�r oppmerksom p� skjermtid: Skjermene fra mobiltelefoner,"),

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
app.MapPost("/api/AddComment", (CommentResponse comment) =>
{
    // get post by id get user by id post.comment.add(new comment(user,content))
    var current = posts.Count();
    var target = posts.SingleOrDefault(item => item.Id == comment.PostId);
    var currentUser = inmemoryDb.SingleOrDefault(item => item.Id == comment.UserId);
    target.Comments.Add(new Comment(currentUser, comment.Content, comment.PostId));
    if(current == posts.Count()) { return "noe gikk galt"; }
    else { return "yipi"; }
});

app.Run();