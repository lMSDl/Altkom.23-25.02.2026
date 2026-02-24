using Models;
using Services.Interfaces;

namespace Services.InMemory
{
    public class ProductsService : IProductsService
    {
        //private IEnumerable<Product> _entities; //IEnumerable nie pozwala na dodawanie, usuwanie i modyfikowanie elementów kolekcji, ponieważ jest to interfejs tylko do odczytu.
        //Aby móc modyfikować kolekcję produktów, należy użyć innego typu kolekcji, takiego jak ICollection<Product>, który implementuje interfejs IEnumerable<Product> i umożliwia dodawanie, usuwanie i modyfikowanie elementów kolekcji.
        private ICollection<Product> _entities;

        public ProductsService()
        {
            //_entities = new List<Product>(); //inicjalizacja kolekcji, która pozwala na przechowywanie obiektów typu Product. List<Product> jest implementacją interfejsu IEnumerable<Product>, który umożliwia iterowanie po kolekcji produktów. Dzięki temu możemy dodawać, usuwać i modyfikować produkty w tej kolekcji.
            _entities = []; // sktócona wersja inicjalizacji kolekcji, dostępna od C# 9.0, która pozwala na tworzenie pustych kolekcji bez konieczności używania słowa kluczowego new. Jest to bardziej zwięzła i czytelna składnia, która poprawia czytelność kodu i ułatwia jego pisanie.
        }

        public void Create(Product entity)
        {
            int maxId = 0;
            foreach (var product in _entities)
            {
                if (product.Id > maxId)
                {
                    maxId = product.Id;
                }
            }

            entity.Id = maxId + 1;
            _entities.Add(entity);
        }

        public bool Delete(int id)
        {
            Product? entity = Read(id);
            if(entity is null)
            {
                return false;
            }

            _entities.Remove(entity);
            return true;
        }

        public Product? Read(int id)
        {
            Product? result = null;
            foreach (var entity in _entities)
            {
                if (entity.Id == id)
                {
                    result = entity;
                    break;
                }
            }

            return result;
        }

        public IEnumerable<Product> ReadAll()
        {
            //return new List<Product>(_entities);
            return [.._entities]; //skrócona wersja tworzenia nowej kolekcji na podstawie istniejącej, dostępna od C# 9.0, która pozwala na tworzenie nowej kolekcji, która zawiera wszystkie elementy z istniejącej kolekcji. Jest to bardziej zwięzła i czytelna składnia, która poprawia czytelność kodu i ułatwia jego pisanie.
        }

        public bool Update(int id, Product entity)
        {
            /*Product? existingEntity = Read(id);
            if (existingEntity is null)
            {
                return false;
            }            */

            if (!Delete(id))
            {
                return false;
            }

            entity.Id = id;
            _entities.Add(entity);

            return true;
        }
    }
}
