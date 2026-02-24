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
            Entity? result = null;
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

        public IEnumerable<Entity> ReadAll()
        {
            return [.. _entities];
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
