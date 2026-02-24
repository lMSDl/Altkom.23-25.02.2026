//instrukcje najwyższego poziomu - top-level statements
//są to instrukcje, które można umieścić bezpośrednio w przestrzeni nazw, bez konieczności definiowania klasy i metody Main. Kompilator automatycznie generuje klasę i metodę Main, która jest punktem wejścia do programu. Dzięki temu kod staje się bardziej zwięzły i czytelny, zwłaszcza dla prostych programów.
//Wszystko co znajduje się w pliku z top-level statements jest otoczone metodą Main

using ConsoleApp;
using ConsoleApp.Models;
using System.IO.Pipes;

//Introduction.Run();

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

product = new Product("Czajnik", DateTime.Now.AddYears(5));
Console.WriteLine(product.FullInfo);


Product product1 = new Product("Camera", DateTime.Now.AddYears(2));
product1.Price = 1000 + 3;
Console.WriteLine(product1.FullInfo);

Product product2 = new Product("Headphones", DateTime.Now.AddYears(1));
product2.Price = 500;
Console.WriteLine(product2.FullInfo);

Product bundle = product1 + product2;
Console.WriteLine(bundle.FullInfo);

//bundle.Price = bundle.Price + 100;
bundle.Price = bundle + 100;

Console.WriteLine(bundle[1]);
bundle[1] = "ala ma kota";
Console.WriteLine(bundle[1]);
Console.WriteLine(bundle["NaMe"]);

//utworzenie obiektu klasy pizza z wykorzystaniem inicjalizatora obiektów
//pozwala na przypisanie wartości do właściwości obiektu w momencie jego tworzenia, co poprawia czytelność kodu i ułatwia jego pisanie.
//Inicjalizator obiektów jest szczególnie przydatny, gdy chcemy ustawić wiele właściwości obiektu w jednym miejscu, zamiast przypisywać wartości do nich osobno po utworzeniu obiektu. Składnia inicjalizatora obiektów polega na umieszczeniu listy właściwości i ich wartości wewnątrz nawiasów klamrowych {} po utworzeniu obiektu.
Pizza pizza = new Pizza() { HasHam = true, HasCheese = true, HasOlives = true };

Pizza pizza2 = new Pizza(hasPepperoni: true, hasCheese: true ) { HasMushrooms = true, HasCheese = false};


Console.WriteLine();

double a = 0.1d;
Console.WriteLine(a);
double b = 0.2d;
Console.WriteLine(b);
double c = a + b;
Console.WriteLine(c);

Console.WriteLine(c == 0.3d);

Console.WriteLine(float.MaxValue);
Console.WriteLine(double.MaxValue);
Console.WriteLine(decimal.MaxValue);
Console.WriteLine(421521523532m/3m);
