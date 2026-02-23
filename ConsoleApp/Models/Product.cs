//namespace - przestrzeń nazw, czyli "adres" pod którym "mieszka" klasa
//namespace zaciągamy używając "using"
namespace ConsoleApp.Models
{
    //klasa Product - klasa, która reprezentuje produkt
    //class - szablon opisujący zachowania i cechy obiektu (instancji klasy), które są tworzone na jej podstawie
    //pełna nazwa klasy to <namespace>.<nazwa>
    //internal - modyfikator dostępu - oznacza, że z klasy można korzystać tylko w obrębie tego samego zestawu (assembly), czyli w tym samym projekcie. Klasa oznaczona jako internal nie będzie dostępna dla innych projektów, nawet jeśli są one częścią tej samej solucji. Jest to przydatne, gdy chcemy ukryć implementację klasy przed innymi projektami, ale nadal chcemy mieć możliwość korzystania z niej wewnątrz naszego projektu.
    //public - modyfikator dostępu - oznacza, że z klasy można korzystać z dowolnego miejsca w kodzie, zarówno wewnątrz tego samego projektu, jak i w innych projektach, które odwołują się do tego projektu. Klasa oznaczona jako public jest dostępna dla wszystkich innych klas i projektów, co pozwala na szerokie udostępnianie jej funkcjonalności. Jest to przydatne, gdy chcemy, aby klasa była dostępna dla innych części naszego kodu lub dla innych projektów, które mogą korzystać z jej funkcji.
    //brak modyfikatora = najniższy dostępny - w przypadku class to internal
    internal class Product
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



        //pole - zmienna, która przechowuje wartość
        //private - modyfikator dostępu - oznacza, że z pola można korzystać tylko wewnątrz tej samej klasy. Pole oznaczone jako private nie będzie dostępne dla innych klas, nawet jeśli są one częścią tego samego projektu. Jest to przydatne, gdy chcemy ukryć implementację pola przed innymi klasami, ale nadal chcemy mieć możliwość korzystania z niego wewnątrz naszej klasy.
        //inne możliwe modyfikatory: public, internal, protected
        //pola zazwyczaj są prywatne ze względu na hermetyzację, a dostęp realizowany jest przez metody getter i setter
        //nazwa pola zaczyna się od podkreślnika, żeby zaznaczyć, że jest to pole prywatne (konwencja c#)
        private DateTime _productionDate;

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

        //Property - właściwości

        //auto-property
        //integruje w sobie pole + metody dostępowe
        public string? Name { get; set; } = string.Empty;

        //jest możliwoć zmiany modyfikatora dla getter i setter
        public int Id { get; private set; }
        public float Price { get; set; }

        //full-property
        private DateTime _expirationDate; //backfiled dla property
        public DateTime ExpirationDate
        {
            //getter dla property
            get
            {
                return _expirationDate;
            }

            //setter dla property - nie ma jawnego parametru. Wartość, którą chcemy przypisać do property, jest dostępna przez słowo kluczowe value
            set
            {
                _expirationDate = value.Date;
            }
        }

        //od .net 10 można używać skróconej składni dla full-property, która pozwala na zdefiniowanie property bez konieczności tworzenia osobnego pola. W takim przypadku kompilator automatycznie generuje pole, które jest używane do przechowywania wartości property.
        //Dzięki temu kod staje się bardziej zwięzły i czytelny, zwłaszcza gdy nie potrzebujemy dodatkowej logiki w getterze lub setterze.
        public string Description
        {
            get
            {
                return field;
            }
            set
            {
                field = value;
            }
        }

        //read-only property - property, które ma tylko getter, co oznacza, że jego wartość można ustawić tylko w konstruktorze lub podczas deklaracji, a nie można jej zmienić po utworzeniu obiektu. Read-only property jest przydatne, gdy chcemy mieć pewność, że wartość danej właściwości pozostanie niezmieniona po utworzeniu obiektu, co może być ważne dla zachowania spójności danych lub dla zapewnienia bezpieczeństwa w przypadku właściwości, które nie powinny być modyfikowane po utworzeniu obiektu.
        public string FullInfo
        {
            get
            {
                //return "Id: " + Id + ", Name: " + Name + ", Production Date: " + _productionDate + ", Expiration Date: " + _expirationDate + ", Description: " + Description;
                //return string.Format("Id: {0}, Name: {1}, Production Date: {2}, Expiration Date: {3}, Description: {4}", Id, Name, _productionDate, _expirationDate, Description);
                //interpolacja stringów - pozwala na wstawianie wartości zmiennych bezpośrednio do stringa, co poprawia czytelność kodu i ułatwia jego pisanie. Aby użyć interpolacji stringów, należy poprzedzić string literą 'f' lub '$', a następnie umieścić zmienne wewnątrz nawiasów klamrowych {} w miejscu, gdzie chcemy je wstawić do stringa.
                return $"Id: {Id}, Name: \"{Name}\", {{Production Date: {_productionDate}, Expiration Date: {_expirationDate}}}, Description: {Description}";
            }
        }

        public string FullInfo2 => $"Id: {Id}, Name: \"{Name}\", {{Production Date: {_productionDate}, Expiration Date: {_expirationDate}}}, Description: {Description}";

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
    }
}
