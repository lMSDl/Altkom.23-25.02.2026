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
    internal partial class Product
    {
        //pole - zmienna, która przechowuje wartość
        //private - modyfikator dostępu - oznacza, że z pola można korzystać tylko wewnątrz tej samej klasy. Pole oznaczone jako private nie będzie dostępne dla innych klas, nawet jeśli są one częścią tego samego projektu. Jest to przydatne, gdy chcemy ukryć implementację pola przed innymi klasami, ale nadal chcemy mieć możliwość korzystania z niego wewnątrz naszej klasy.
        //inne możliwe modyfikatory: public, internal, protected
        //pola zazwyczaj są prywatne ze względu na hermetyzację, a dostęp realizowany jest przez metody getter i setter
        //nazwa pola zaczyna się od podkreślnika, żeby zaznaczyć, że jest to pole prywatne (konwencja c#)
        private DateTime _productionDate;

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

    }
}
