using ItemsManager;
using Models;
using Services.Interfaces;
using System.Globalization;


/*Song song1 = new Song() { Title = "Song1", Artist = "Artist1" };
Song song2 = new Song() { Title = "Song2", Artist = "Artist2" };

Podcast podcast1 = new Podcast { Title = "Podcast", EpisodNumber = 1 };
Podcast podcast2 = new Podcast { Title = "Podcast", EpisodNumber = 2 };

IEnumerable<IPlayable> playables = new List<IPlayable> { podcast1, podcast2, song1, song2 };

foreach (var playable in playables)
{
    Player.PlayItem(playable);
}*/

EntityManager<Product> manager = new ProductsManager();

/*EntityManager<Pet> manager = new DelegateManager<Pet>(
    () => new Pet(),
    pet => pet.Age = EntityManager<Pet>.ReadInt("Age: "),
    (current, edited) => edited.Age = EntityManager<Pet>.ReadInt($"Age ({current.Age}): ", current.Age)
    );*/



manager.Run();