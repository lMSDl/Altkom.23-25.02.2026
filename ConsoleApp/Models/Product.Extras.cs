
namespace ConsoleApp.Models
{

    internal partial class Product
    {
        
        //przeciążenie operatorów - możliwość zdefiniowania własnego zachowania operatorów dla naszej klasy. Dzięki temu możemy używać operatorów takich jak +, -, *, / itp. w kontekście naszych obiektów, co może poprawić czytelność kodu i ułatwić jego pisanie. Przeciążenie operatorów polega na zdefiniowaniu metody statycznej, która implementuje zachowanie danego operatora dla naszej klasy. Metoda ta musi mieć odpowiednią sygnaturę, która określa typy argumentów i typ zwracany.
        //możemy przeciążać zarówno operatory binarne (np. +, -, *, /), które działają na dwóch operandach, jak i operatory unarne (np. ++, --), które działają na jednym operandzie. Przeciążenie operatorów pozwala na tworzenie bardziej naturalnych i intuicyjnych interakcji z naszymi obiektami, co może poprawić czytelność kodu i ułatwić jego pisanie.
        //można także przeciążać operatory porównania (np. ==, !=, <, >), ale w takim przypadku należy pamiętać o zachowaniu spójności między operatorami porównania a metodami Equals i GetHashCode, aby uniknąć nieoczekiwanych zachowań podczas porównywania obiektów.
        public static Product operator +(Product p1, Product p2)
        {
            Product bundle = new Product();
            bundle.Name = $"{p1.Name} + {p2.Name}";
            bundle.Price = (p1.Price + p2.Price) * 0.9f;
            bundle.ExpirationDate = p1.ExpirationDate < p2.ExpirationDate ? p1.ExpirationDate : p2.ExpirationDate;
            //warunek ? wartość jeśli prawda : wartość jeśli fałsz
            return bundle;
        }

        //możemy mieszać typy operandów, ale przynajmniej jeden z nich musi być typu naszej klasy. W tym przypadku, operator + jest przeciążony dla kombinacji Product i float, co pozwala na dodanie ceny do produktu, co może być wygodne i czytelne, zwłaszcza gdy chcemy szybko obliczyć nową cenę produktu po dodaniu dodatkowych kosztów lub rabatów.
        public static float operator +(Product p, float price)
        {
            return p.Price + price;
        }

        //indexer - pozwala na dostęp do obiektu danej klasy jak do tablicy lub słownika
        //możemy zdefiniowac sam getter lub też sam setter lub oba jednocześnie
        public string this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return Id.ToString();
                    case 1:
                        return Name;
                    case 2:
                        return Description;
                    case 3:
                        return FullInfo;
                    case 4:
                        return _expirationDate.ToString();
                    case 5:
                        return _productionDate.ToString();
                    default:
                        return string.Empty;
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        Id = int.Parse(value);
                        break;
                    case 1:
                        Name = value;
                        break;
                    case 2:
                        Description = value;
                        break;
                    case 3:
                        //FullInfo = value; - nie można przypisać wartości do read-only property
                        break;
                    case 4:
                        ExpirationDate = DateTime.Parse(value);
                        break;
                    case 5:
                        SetProductionDate(DateTime.Parse(value));
                        break;
                }
            }

        }

        //indexem może być dowolny typ
        public string this[string index]
        {
            get
            {
                return index.ToLower() switch
                {
                    "id" => Id.ToString(),
                    "name" => Name,
                    "description" => Description,
                    "fullinfo" => FullInfo,
                    "expirationdate" => _expirationDate.ToString(),
                    "productiondate" => _productionDate.ToString(),
                    _ => string.Empty
                };
            }
        }
    }
}
