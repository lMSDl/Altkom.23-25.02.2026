using Models;
using Services.Interfaces;

namespace ItemsManager
{
    // <T> - parametr generyczny, który pozwala na tworzenie klas, metod i interfejsów, które mogą działać z różnymi typami danych. Dzięki temu możemy tworzyć bardziej elastyczne i wielokrotnego użytku komponenty, które mogą być używane z różnymi typami danych bez konieczności duplikowania kodu.
    // where T : - ograniczenie generyczne, które określa, że typ T musi dziedziczyć po klasie Entity. Oznacza to, że możemy używać tylko tych typów danych, które są klasami dziedziczącymi po Entity, co pozwala na korzystanie z właściwości i metod zdefiniowanych w klasie Entity w naszej klasie EntityManager.
    internal abstract class EntityManager<T> where T : Entity
    {
        IEntityService service = new Services.InMemory.EntityService();


        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                foreach (var entity in service.ReadAll())
                {
                    Console.WriteLine(entity);
                }

                Console.WriteLine("Commands: create, edit, delete, exit");

                string input = Console.ReadLine()!;

                switch (input.ToLower())
                {
                    case "create":
                        Create();
                        break;
                    case "edit":
                        Edit();
                        break;
                    case "delete":
                        Delete();
                        break;
                    case "exit":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }

                Console.WriteLine("Press any button..");
                Console.ReadKey();
            }
        }

        void Edit()
        {
            int id = ReadInt("Id: ");
            T? entity = service.Read(id) as T;
            if (entity == null)
            {
                Console.WriteLine("Id not found");
                return;
            }

            var newEntity = CreateEntity();
            newEntity.Name = ReadString($"Name ({entity.Name}): ", entity.Name);
            ExtraEdit(entity, newEntity);

            service.Update(id, newEntity);
        }

        protected abstract void ExtraEdit(T current, T edited);


        void Create()
        {
            var entity = CreateEntity();
            //var entity = Activator.CreateInstance<T>();
            entity.Name = ReadString("Name: ");
            ExtraCreate(entity);


            service.Create(entity);
        }

        protected abstract T CreateEntity();
        protected abstract void ExtraCreate(T entity);


        void Delete()
        {
            string input;
            int id;

            Console.Write("Id: ");
            input = Console.ReadLine()!;

            //try-catch - służy do obsługi wyjątków
            //w bloku try umieszczamy kod, który może rzucić wyjątek
            try
            {
                id = int.Parse(input);
            }
            //catch (bez parametrów) - przechwytujemy wszystkie wyjątki i nie dostajemy informacji jaki to wyjątek
            catch
            {
                id = 0;
            }

            if (!service.Delete(id))
                Console.WriteLine("Id not found");


        }

        protected DateTime ReadDate(string label, DateTime @default = default)
        {
            Console.Write(label);
            var input = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(input))
                return @default;

            DateTime dateTime;
            try
            {
                dateTime = DateTime.Parse(input);
                if (dateTime > DateTime.Now)
                    throw new InvalidDataException("Date cannot be in the future");
            }
            //foltrowanie wyjątków - możemy obsługiwać różne wyjątki w różny sposób
            //catch tylko z typem wyjątku - oznacza, że łapiemy wyjątki dziedziczące po wskazanym typie
            catch (FormatException)
            {
                Console.WriteLine("Invalid date fomat");
                dateTime = ReadDate(label);
            }
            //catch z intancją wyjątku - dostajemy dostęp do informacji o wyjątku
            catch (InvalidDataException e)
            {
                Console.WriteLine(e.Message);
                dateTime = ReadDate(label);
            }
            //kolejnosc bloków ma znaczenie - najpierw sprawdzamy szczególne wyjątki, a na koniec ogólne
            catch /*(Exception e)*/
            {
                Console.WriteLine("Unknown error");
                dateTime = ReadDate(label);
            }


            return dateTime;
        }

        /*string ReadString(string label)
        {
            Console.Write(label);
            return Console.ReadLine()!;
        }*/

        //@ - pozwala używać słów kluczowych jako nazw zmiennych, parametrów itp. - przydatne gdy chcemy zachować czytelność kodu i użyć słowa kluczowego jako nazwy
        //parametr domyślny - pozwala na wywołanie metody bez podawania wartości dla tego parametru, jeśli nie jest on wymagany. Dziala tak jakby metoda była przeciążona o wersję bez tego parametru
        string ReadString(string label, string @default = "")
        {
            Console.Write(label);
            var @string = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(@string))
            {
                return @default;
            }
            return @string;
        }

        protected float ReadFloat(string label, float @default = 0)
        {
            Console.Write(label);
            var input = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(input))
                return @default;

            float value;
            //tryParse - próbuje przekonwertować string na wskazany typ, jeśli się nie uda to nie rzuca wyjątkiem tylko zwraca false
            //wartość przekonwertowana jest zwracana przez parametr out
            bool success = float.TryParse(input, out value);

            if (success)
            {
                return value;
            }
            Console.WriteLine("Invalid price");
            return ReadFloat(label);
        }


        int ReadInt(string label)
        {
            int value = 4;
            if (!TryReadInt(label, out value))
            {
                ReadInt(label);
            }
            return value;
        }


        //worzymy własną metodę zgodnie z Try Pattern - metoda, która próbuje wykonać jakąś operację i zwraca boola informującego o sukcesie oraz wynik tej operacji przez parametr out
        bool TryReadInt(string label, out int result)
        {
            Console.Write(label);
            string input = Console.ReadLine()!;

            try
            {
                result = int.Parse(input);

                return true;
            }
            catch
            {
                Console.WriteLine("Invalid number format");
                result = default;
                return false;
            }
        }

    }
}
