using Services.Interfaces;

IProductsService service = new Services.InMemory.ProductsService();

service.Create(new Models.Product() { Name = "Laptop", Price = 2000 });
service.Create(new Models.Product() { Name = "Czajnik", Price = 100 });

foreach (var product in service.ReadAll())
{
    Console.WriteLine($"{product.Id} - {product.Name} - {product.Price}");
}
