using Services.Interfaces;
using System.Reflection.Emit;


/*Song song1 = new Song() { Title = "Song1", Artist = "Artist1" };
Song song2 = new Song() { Title = "Song2", Artist = "Artist2" };

Podcast podcast1 = new Podcast { Title = "Podcast", EpisodNumber = 1 };
Podcast podcast2 = new Podcast { Title = "Podcast", EpisodNumber = 2 };

IEnumerable<IPlayable> playables = new List<IPlayable> { podcast1, podcast2, song1, song2 };

foreach (var playable in playables)
{
    Player.PlayItem(playable);
}*/


IProductsService service = new Services.InMemory.ProductsService();
service.Create(new Models.Product() { Name = "Laptop", Price = 2000 });
service.Create(new Models.Product() { Name = "Czajnik", Price = 100 });

bool exit = false;

while (!exit)
{
    Console.Clear();
    foreach (var product in service.ReadAll())
    {
        Console.WriteLine($"{product.Id} - {product.Name} - {product.Price} - {product.CreatedAt}");
    }

    Console.WriteLine("Commands: create, delete, exit");

    string input = Console.ReadLine()!;

    switch (input.ToLower())
    {
        case "create":
            Create();
            break;
        case "delete":
            Delete();
            break;
        case "exit":
            exit = true;
            break;
        default:
            Console.WriteLine("Unknown command");
            break;
    }

    Console.WriteLine("Press any button..");
    Console.ReadKey();
}

void Create()
{
    var entity = new Models.Product();
    entity.Name = ReadString("Name: ");
    entity.CreatedAt = ReadDate("Created at: ");

    service.Create(entity);
}

void Delete()
{
    string input;
    int id;

    Console.Write("Id: ");
    input = Console.ReadLine()!;

    //try-catch - służy do obsługi wyjątków
    //w bloku try umieszczamy kod, który może rzucić wyjątek
    try
    {
        id = int.Parse(input);
    }
    //catch (bez parametrów) - przechwytujemy wszystkie wyjątki i nie dostajemy informacji jaki to wyjątek
    catch
    {
        id = 0;
    }

    if (!service.Delete(id))
        Console.WriteLine("Id not found");
}

static DateTime ReadDate(string label)
{
    Console.Write(label);
    var input = Console.ReadLine()!;
    DateTime dateTime;
    try
    {
        dateTime = DateTime.Parse(input);
        if (dateTime > DateTime.Now)
            throw new InvalidDataException("Date cannot be in the future");
    }
    //foltrowanie wyjątków - możemy obsługiwać różne wyjątki w różny sposób
    //catch tylko z typem wyjątku - oznacza, że łapiemy wyjątki dziedziczące po wskazanym typie
    catch (FormatException)
    {
        Console.WriteLine("Invalid date fomat");
        dateTime = ReadDate(label);
    }
    //catch z intancją wyjątku - dostajemy dostęp do informacji o wyjątku
    catch (InvalidDataException e)
    {
        Console.WriteLine(e.Message);
        dateTime = ReadDate(label);
    }
    //kolejnosc bloków ma znaczenie - najpierw sprawdzamy szczególne wyjątki, a na koniec ogólne
    catch /*(Exception e)*/
    {
        Console.WriteLine("Unknown error");
        dateTime = ReadDate(label);
    }

    return dateTime;
}

static string ReadString(string label)
{
    Console.Write(label);
    return Console.ReadLine()!;
}