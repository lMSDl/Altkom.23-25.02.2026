using Models;

namespace ItemsManager
{
    internal class ProductsManager : EntityManager
    {
        protected override Entity CreateEntity()
        {
            return new Product();
        }

        protected override void ExtraCreate(Entity entity)
        {
            var product = (Product)entity;
            product.Price = ReadFloat("Price: ");
            product.CreatedAt = ReadDate("Created at: ");
        }

        protected override void ExtraEdit(Entity current, Entity edited)
        {
            var currentProduct = (Product)current;
            var editedProduct = (Product)edited;
            editedProduct.Price = ReadFloat($"Price ({currentProduct.Price}): ", currentProduct.Price);
            editedProduct.CreatedAt = ReadDate($"Created at ({currentProduct.CreatedAt}): ", currentProduct.CreatedAt);
        }
    }
}
