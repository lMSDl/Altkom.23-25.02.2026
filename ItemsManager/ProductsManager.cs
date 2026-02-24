using Models;

namespace ItemsManager
{
    internal class ProductsManager : EntityManager<Product>
    {
        protected override Product CreateEntity()
        {
            return new Product();
        }

        protected override void ExtraCreate(Product entity)
        {
            entity.Price = ReadFloat("Price: ");
            entity.CreatedAt = ReadDate("Created at: ");
        }

        protected override void ExtraEdit(Product current, Product edited)
        {
            edited.Price = ReadFloat($"Price ({current.Price}): ", current.Price);
            edited.CreatedAt = ReadDate($"Created at ({current.CreatedAt}): ", current.CreatedAt);
        }
    }
}
