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
    return new Posts(inmemoryDb[2], "Hvordan få bedre søvn for bedre mental helse\": Søvn spiller en viktig rolle i vår mentale helse, og å forbedre søvnkvaliteten kan ha en positiv innvirkning på humør, stressnivå og energinivå i løpet av dagen. Dette kan inkludere å opprettholde en jevn søvnplan, skape et behagelig sovemiljø og redusere bruk av elektroniske enheter før sengetid.\r\n                Unngå koffein og alkohol før sengetid: Koffein og alkohol kan forstyrre søvnmønstre og føre til dårligere søvnkvalitet. Prøv å begrense inntaket av koffein og alkohol, spesielt i timene før sengetid, for å sikre at du får en god natts søvn.\r\n                Prøv avslapningsteknikker: Avslapningsteknikker som yoga, meditasjon eller dyp pusting kan hjelpe deg med å roe ned før sengetid og forbedre søvnkvaliteten. Prøv å inkludere disse teknikkene i din daglige rutine for å redusere stress og angst.\r\n                Vær oppmerksom på skjermtid: Skjermene fra mobiltelefoner, datamaskiner og TV-er kan utsette hjernen for blått lys, som kan forstyrre søvnrytmen. Prøv å redusere skjermtiden din i timene før sengetid, og bruk gjerne nattmodus på enhetene dine for å redusere mengden av blått lys som utsettes for øynene dine.`,\r\n                ");
});

app.MapGet("/api/FriendsList", () =>
{
    return inmemoryDb;
});

app.Run();