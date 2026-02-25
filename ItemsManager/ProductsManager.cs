using Models;

namespace ItemsManager
{
    internal class ProductsManager : EntityManager<Product>
    {
        public ProductsManager(string filePath) : base(filePath) {
        
         service.Create(new Product() { Name = "mleko", Price = 10.5f, CreatedAt = new DateTime(2024, 1, 1) });
            service.Create(new Product() { Name = "chleb", Price = 5.0f, CreatedAt = new DateTime(2024, 2, 1) });
            service.Create(new Product() { Name = "jajka", Price = 12.0f, CreatedAt = new DateTime(2024, 3, 1) });
            service.Create(new Product() { Name = "masło", Price = 15.0f, CreatedAt = new DateTime(2024, 4, 1) });

        }
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
