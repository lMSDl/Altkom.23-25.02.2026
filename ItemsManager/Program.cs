using Services.Interfaces;


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

    Console.WriteLine("Commands: create, edit, delete, exit");

    string input = Console.ReadLine()!;

    switch (input.ToLower())
    {
        case "create":
            Create();
            break;
        case "edit":
            Edit();
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

void Edit()
{
    int id = ReadInt("Id: ");
    var entity = service.Read(id);
    if (entity == null)
    {
        Console.WriteLine("Id not found");
        return;
    }

    var newEntity = new Models.Product
    {
        Name = ReadString($"Name ({entity.Name}): ", entity.Name),
        Price = ReadFloat($"Price ({entity.Price}): ", entity.Price),
        CreatedAt = ReadDate($"Created at ({entity.CreatedAt}): ", entity.CreatedAt)
    };


    service.Update(id, newEntity);
}


void Create()
{
    var entity = new Models.Product();
    entity.Name = ReadString("Name: ");
    entity.Price = ReadFloat("Price: ");
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

static DateTime ReadDate(string label, DateTime @default = default)
{
    Console.Write(label);
    var input = Console.ReadLine()!;
    if(string.IsNullOrWhiteSpace(input))
        return @default;

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

/*string ReadString(string label)
{
    Console.Write(label);
    return Console.ReadLine()!;
}*/

//@ - pozwala używać słów kluczowych jako nazw zmiennych, parametrów itp. - przydatne gdy chcemy zachować czytelność kodu i użyć słowa kluczowego jako nazwy
//parametr domyślny - pozwala na wywołanie metody bez podawania wartości dla tego parametru, jeśli nie jest on wymagany. Dziala tak jakby metoda była przeciążona o wersję bez tego parametru
string ReadString(string label, string @default = "")
{
    Console.Write(label);
    var @string = Console.ReadLine()!;
    if (string.IsNullOrWhiteSpace(@string))
    {
        return @default;
    }
    return @string;
}

float ReadFloat(string label, float @default = 0)
{
    Console.Write(label);
    var input = Console.ReadLine()!;

    if(string.IsNullOrWhiteSpace(input))
        return @default;

    float value;
    //tryParse - próbuje przekonwertować string na wskazany typ, jeśli się nie uda to nie rzuca wyjątkiem tylko zwraca false
    //wartość przekonwertowana jest zwracana przez parametr out
    bool success = float.TryParse(input, out value);

    if (success)
    {
        return value;
    }
    Console.WriteLine("Invalid price");
    return ReadFloat(label);
}


int ReadInt(string label)
{
    int value = 4;
    if (!TryReadInt(label, out value))
    {
        ReadInt(label);
    }
    return value;
}


//worzymy własną metodę zgodnie z Try Pattern - metoda, która próbuje wykonać jakąś operację i zwraca boola informującego o sukcesie oraz wynik tej operacji przez parametr out
bool TryReadInt(string label, out int result)
{
    Console.Write(label);
    string input = Console.ReadLine()!;

    try
    {
        result = int.Parse(input);

        return true;
    }
    catch
    {
        Console.WriteLine("Invalid number format");
        result = default;
        return false;
    }
}
