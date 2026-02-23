
namespace ConsoleApp.Models
{

    //partial - słowo kluczowe, które pozwala na podzielenie definicji klasy na wiele plików. Dzięki temu można organizować kod w bardziej przejrzysty sposób, zwłaszcza gdy klasa jest duża i zawiera wiele metod, właściwości itp.
    //Każdy plik z definicją klasy musi być oznaczony jako partial, a kompilator łączy wszystkie części klasy w jeden spójny typ podczas kompilacji.
    //Jest to szczególnie przydatne, gdy chcemy oddzielić różne aspekty klasy (np. metody, właściwości, zdarzenia) do osobnych plików, co może poprawić czytelność i zarządzanie kodem.
    //Partiale są też wykorzystywane prez generatory kodu, które mogą automatycznie generować część klasy, a programista może dodać własną logikę do innej części klasy bez ryzyka nadpisania wygenerowanego kodu.
    //wymagania: ta sama nazwa, ten sam namespace, ten sam modyfikator dostępu, to samo assembly
    internal partial class Product
    {
        //metoda konstrukcyjna (konstruktor) - bezparametrowy
        //konstruktor ustawia wszystkie pola na wartości domyślne (null dla typów referencyjnych, 0 dla typów wartościowych, false dla bool itp.) lub wartości wskazane przez programistę
        //konstuktory głównie wykorzystywane są w elu wstępnej konfiguracji obiektu
        //budowa: <modyfikator dostępu> <nazwa klasy>(<parametry>)
        //jeśli klasa nie ma żadnego konstruktora, kompilator automatycznie generuje konstruktor bezparametrowy, który ustawia wszystkie pola na wartości domyślne. Jeśli klasa ma zdefiniowany konstruktor, kompilator nie generuje już konstruktora bezparametrowego, więc jeśli chcemy mieć możliwość tworzenia obiektów bez podawania argumentów, musimy jawnie zdefiniować konstruktor bezparametrowy.
        public Product()
        {
            SetProductionDate(DateTime.Now);
        }

        //konstruktor parametrowy - pozwala na ustawienie wartości pól podczas tworzenia obiektu, co może być wygodne i czytelne, zwłaszcza gdy klasa ma wiele pól, które muszą być zainicjalizowane. Konstruktor parametrowy umożliwia przekazanie wartości bezpośrednio do konstruktora, co może poprawić czytelność kodu i ułatwić tworzenie obiektów z określonymi wartościami.
        //przeciążenie metody konstrukcyjnej - możliwość zdefiniowania wielu konstruktorów o tej samej nazwie, ale różniących się listą parametrów. Dzięki temu można tworzyć obiekty na różne sposoby, w zależności od potrzeb, co zwiększa elastyczność i użyteczność klasy.
        //: this() - odwołanie się do innego konstruktora tej samej klasy. W tym przypadku, konstruktor parametrowy wywołuje konstruktor bezparametrowy, co pozwala na wykonanie wspólnej logiki inicjalizacji (ustawienie daty produkcji) przed ustawieniem wartości pola Name. Dzięki temu można uniknąć duplikowania kodu i zapewnić spójność inicjalizacji obiektów. Tak zwany konstruktor teleskopowy
        public Product(string name) : this()
        {
            Name = name;
        }

        //jeśli w klasie występuje jakiś konstruktor parametrowy, to konstuktor bezparametrowy nie zostanie automatycznie wygenerowany
        //jeśli chcemy mieć możliwość tworzenia obiektów bez podawania argumentów, musimy jawnie zdefiniować konstruktor bezparametrowy
        public Product(string name, DateTime expirationDate) : this(name)
        {
            ExpirationDate = expirationDate;
        }


        //getter - do pobierania wartości - metoda zwraca wartość pola lub "przetwarza" ją przed zwróceniem
        //budowa metody: <modyfikator dostępu> <typ zwracany> <nazwa>(<parametry>)
        public DateTime GetProductionDate()
        {
            return _productionDate;
        }
        //setter - do ustawiania wartości - metoda przyjmuje parametr, który możemy przypisać do pola lub "obrobić"
        //void - metoda nie zwraca wartości
        public void SetProductionDate(DateTime productionDate)
        {
            _productionDate = productionDate.Date; //przykład obróbki danych przez wpisaniem w pole
        }

    }
}
