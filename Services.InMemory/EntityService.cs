using Models;
using Services.Interfaces;

namespace Services.InMemory
{
    public class EntityService : IEntityService
    {
        private ICollection<Entity> _entities;

        public EntityService()
        {
            _entities = [];
        }

        public void Create(Entity entity)
        {
            //DefaultIfEmpty - jeśli kolekcja jest pusta, to zwróć kolekcję z jednym elementem o wartości 0, a następnie weź maksymalną wartość i dodaj 1, aby uzyskać nowy unikalny identyfikator.
            entity.Id = _entities.Select(x => x.Id).DefaultIfEmpty(0).Max() + 1;
            _entities.Add(entity);
        }

        public bool Delete(int id)
        {
            Entity? entity = Read(id);
            if (entity is null)
            {
                return false;
            }

            _entities.Remove(entity);
            return true;
        }

        public Entity? Read(int id)
        {
            Entity? result = _entities.SingleOrDefault(x => x.Id == id);
            return result;
        }

        public IEnumerable<Entity> ReadAll()
        {
            return _entities.ToList();
        }

        public bool Update(int id, Entity entity)
        {

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
