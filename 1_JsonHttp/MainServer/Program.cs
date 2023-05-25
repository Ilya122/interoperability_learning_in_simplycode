using MainServer;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var currDir = Path.Combine(Environment.CurrentDirectory,"cats");
Cats cats = Cats.Create(currDir);

app.MapGet("/", () => "Hello to Cat world!");

app.MapGet("/cats", () => $"There are currently {cats.AllCats.Count} cats in the server - meow");

app.MapGet("/cats/{id}", (string id) =>
{
    var cat = cats.AllCats.FirstOrDefault(c => c.Number == id);
    if (cat == null)
    {
        return Results.NotFound();
    }

    var mimeType = "image/jpeg";
    return Results.File(cat.FileName, contentType: mimeType);
});

app.MapPost("/cats", async (IFormFile file) =>
{
    cats.StoreCat(file);
});

app.MapGet("/cat_stats", async () =>
{
    return cats.GetStats();
});

app.Run();


