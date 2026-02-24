using ItemsManager;
using Services.InMemory;
using Services.Interfaces;


Song song1 = new Song() { Title = "Song1", Artist = "Artist1" };
Song song2 = new Song() { Title = "Song2", Artist = "Artist2" };

Podcast podcast1 = new Podcast { Title = "Podcast", EpisodNumber = 1 };
Podcast podcast2 = new Podcast { Title = "Podcast", EpisodNumber = 2 };

IEnumerable<IPlayable> playables = new List<IPlayable> { podcast1, podcast2, song1, song2 };

foreach (var playable in playables)
{
    Player.PlayItem(playable);
}


IProductsService service = new Services.InMemory.ProductsService();

service.Create(new Models.Product() { Name = "Laptop", Price = 2000 });
service.Create(new Models.Product() { Name = "Czajnik", Price = 100 });

foreach (var product in service.ReadAll())
{
    Console.WriteLine($"{product.Id} - {product.Name} - {product.Price}");
}
