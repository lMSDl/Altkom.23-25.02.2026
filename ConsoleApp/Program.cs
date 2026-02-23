
//instrukcje najwyższego poziomu - top-level statements
//są to instrukcje, które można umieścić bezpośrednio w przestrzeni nazw, bez konieczności definiowania klasy i metody Main. Kompilator automatycznie generuje klasę i metodę Main, która jest punktem wejścia do programu. Dzięki temu kod staje się bardziej zwięzły i czytelny, zwłaszcza dla prostych programów.
//Wszystko co znajduje się w pliku z top-level statements jest otoczone metodą Main
using ConsoleApp.Models;

Console.WriteLine("Hello, World!");

//flaga Nullable w pliku csproj - pozwala na włączenie lub wyłączenie obsługi typów nullable w całym projekcie. Gdy flaga Nullable jest ustawiona na enable, kompilator traktuje wszystkie typy referencyjne jako nullable, co oznacza, że mogą one przyjmować wartość null. W takim przypadku, jeśli próbujemy przypisać null do typu referencyjnego, kompilator wygeneruje ostrzeżenie lub błąd, w zależności od ustawień projektu. Flaga Nullable jest szczególnie przydatna w celu poprawy bezpieczeństwa kodu i unikania błędów związanych z null reference exceptions.

int a = 5;
int? b = null; //nullable type używając shorthand syntax
//Nullable - opakowanie typów wartościowych, które pozwala na przypisanie im wartości null. Dzięki temu można reprezentować brak wartości lub nieznaną wartość dla typów takich jak int, double, bool itp. Nullable jest szczególnie przydatny w sytuacjach, gdy chcemy mieć możliwość oznaczenia, że dana wartość jest nieokreślona lub nieistniejąca, co jest niemożliwe do osiągnięcia za pomocą zwykłych typów wartościowych, które zawsze muszą mieć przypisaną wartość.
//Nullable jest implementowany jako struktura generyczna System.Nullable<T>, gdzie T jest typem wartościowym.
Nullable<int> c = null;

    Product product1 = new Product
    {
        Id = 1,
        Name = "Laptop"
    };
ChangeProduct(product1);

Product? product2 = null;
ChangeProduct(product2);


string str1 = "ala ma kota";
string str2 = null;

void ChangeProduct(Product product)
{
       product.Name = "Komputer";
}