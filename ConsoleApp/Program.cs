//instrukcje najwyższego poziomu - top-level statements
//są to instrukcje, które można umieścić bezpośrednio w przestrzeni nazw, bez konieczności definiowania klasy i metody Main. Kompilator automatycznie generuje klasę i metodę Main, która jest punktem wejścia do programu. Dzięki temu kod staje się bardziej zwięzły i czytelny, zwłaszcza dla prostych programów.
//Wszystko co znajduje się w pliku z top-level statements jest otoczone metodą Main

using ConsoleApp.Models;
using System.IO.Pipes;

Product product = new Product();

Console.WriteLine(product.GetType().Name);
Console.WriteLine(product.GetType().Namespace);
Console.WriteLine(product.GetType().FullName);

product.Name = "Laptop";
product.Description = "popsuty";
product.SetProductionDate(DateTime.Now);
product.ExpirationDate = DateTime.Now.AddYears(1);

Console.WriteLine(product.FullInfo2);

product.Description = "naprawiony";
Console.WriteLine(product.FullInfo2);