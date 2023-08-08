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

app.MapGet("/api/Posts", () =>
{
    return new Posts(inmemoryDb[2], "Hvordan f� bedre s�vn for bedre mental helse\": S�vn spiller en viktig rolle i v�r mentale helse, og � forbedre s�vnkvaliteten kan ha en positiv innvirkning p� hum�r, stressniv� og energiniv� i l�pet av dagen. Dette kan inkludere � opprettholde en jevn s�vnplan, skape et behagelig sovemilj� og redusere bruk av elektroniske enheter f�r sengetid.\r\n                Unng� koffein og alkohol f�r sengetid: Koffein og alkohol kan forstyrre s�vnm�nstre og f�re til d�rligere s�vnkvalitet. Pr�v � begrense inntaket av koffein og alkohol, spesielt i timene f�r sengetid, for � sikre at du f�r en god natts s�vn.\r\n                Pr�v avslapningsteknikker: Avslapningsteknikker som yoga, meditasjon eller dyp pusting kan hjelpe deg med � roe ned f�r sengetid og forbedre s�vnkvaliteten. Pr�v � inkludere disse teknikkene i din daglige rutine for � redusere stress og angst.\r\n                V�r oppmerksom p� skjermtid: Skjermene fra mobiltelefoner, datamaskiner og TV-er kan utsette hjernen for bl�tt lys, som kan forstyrre s�vnrytmen. Pr�v � redusere skjermtiden din i timene f�r sengetid, og bruk gjerne nattmodus p� enhetene dine for � redusere mengden av bl�tt lys som utsettes for �ynene dine.`,\r\n                ");
});

app.MapGet("/api/FriendsList", () =>
{
    return inmemoryDb;
});

app.Run();