using ItemsManager.Encryption;
using Models;
using Services.Interfaces;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Xml.Serialization;

namespace ItemsManager
{
    // <T> - parametr generyczny, który pozwala na tworzenie klas, metod i interfejsów, które mogą działać z różnymi typami danych. Dzięki temu możemy tworzyć bardziej elastyczne i wielokrotnego użytku komponenty, które mogą być używane z różnymi typami danych bez konieczności duplikowania kodu.
    // where T : - ograniczenie generyczne, które określa, że typ T musi dziedziczyć po klasie Entity. Oznacza to, że możemy używać tylko tych typów danych, które są klasami dziedziczącymi po Entity, co pozwala na korzystanie z właściwości i metod zdefiniowanych w klasie Entity w naszej klasie EntityManager.
    internal abstract class EntityManager<T> where T : Entity
    {
        protected IEntityService service = new Services.InMemory.EntityService();
        private readonly string _filePath;

        JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseUpper,
            IgnoreReadOnlyProperties = true,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        protected EntityManager(string filePath)
        {
            _filePath = filePath;
        }

        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine( string.Join('\n', service.ReadAll().Select(x => x.ToString())) );

                Console.WriteLine("Commands: create, edit, delete, json, xml, import, exit");

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
                    case "json":
                        ToJson();
                        break;
                    case "xml":
                        ToXml();
                        break;
                    case "import":
                        Import();
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

        private void Import()
        {
            string fileName = ReadString("File name: ").Trim('"');
            if(!File.Exists(fileName))
            {
                Console.WriteLine("File not found");
                return;
            }

            /*using FileStream fileStream = new FileStream(fileName, FileMode.Open);
            using StreamReader reader = new StreamReader(fileStream);
            string data = reader.ReadToEnd();
            Console.WriteLine(data);*/
            List<T> items = null;
            switch(Path.GetExtension(fileName))
            {
                case ".json":
                    var bytes = File.ReadAllBytes(fileName);
                    var decryptedData = new SymmetricEncryption().Decrypt(bytes, "alamakota");
                    

                    items = JsonSerializer.Deserialize<List<T>>(decryptedData, _options);
                    
                    break;
                case ".xml":
                    XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                    FileStream fileStream = new FileStream(fileName, FileMode.Open);
                    items = (List<T>)serializer.Deserialize(fileStream)!;
                    break;
            }
            if (items is null)
                return;

            foreach (var item in items)
            {
                service.Create(item);
            }

        }

        private void SaveToFile(string data, string fileName)
        {
            Console.Write("Save to file? ");
            string input = Console.ReadLine()!;
            if (input.ToLower() != "yes" && input.ToLower() != "y")
            {
                return;
            }
            //File - fasada, która udostępnia proste metody do operacji na plikach, takich jak tworzenie, odczytywanie, zapisywanie i usuwanie plików.
            //Umożliwia łatwe zarządzanie plikami bez konieczności bezpośredniego korzystania z klas strumieniowych.
            //File.WriteAllText(Path.Combine(_filePath, fileName), data);

            var encryptedData = new SymmetricEncryption().Encrypt(data, "alamakota");
            File.WriteAllBytes(Path.Combine(_filePath, fileName), encryptedData);
        }

        private void SaveToFileUsingStream(string data, string fileName)
        {
            Console.Write("Save to file? ");
            string input = Console.ReadLine()!;
            if(input.ToLower() != "yes"  && input.ToLower() != "y")
            {
                return;
            }
            //klasa strumieniowa - pozwala na odczyt i zapis danych do pliku, pamięci itp. za pomocą strumieni bajtów. Umożliwia efektywne zarządzanie zasobami i operacjami we/wy.
            //using - służy do automatycznego zwalniania zasobów, takich jak strumienie, po zakończeniu ich używania. Zapewnia, że metoda Dispose() zostanie wywołana na obiekcie, nawet jeśli wystąpi wyjątek, co pozwala na uniknięcie wycieków pamięci i innych problemów związanych z zarządzaniem zasobami.
            using FileStream fileStream = new FileStream(Path.Combine(_filePath, fileName), FileMode.Create);

            //strumienie domyślnie obsługują dane w postaci bajtów, dlatego musimy przekonwertować nasze dane tekstowe na bajty przed zapisaniem ich do strumienia. Możemy to zrobić za pomocą klasy Encoding, która umożliwia konwersję między różnymi formatami kodowania znaków a bajtami. W tym przypadku używamy kodowania UTF-8, które jest powszechnie stosowane do reprezentacji tekstu w formie bajtów.
            /*var bytes = Encoding.UTF8.GetBytes(data);
            fileStream.Write(bytes);*/

            //klasa pomocnicza do zapisu danych tekstowych do strumienia. Umożliwia łatwe zapisywanie tekstu do pliku, pamięci itp. za pomocą strumieni bajtów. Zapewnia funkcje formatowania i kodowania tekstu, co ułatwia zarządzanie danymi tekstowymi w strumieniach.
            using StreamWriter writer = new StreamWriter(fileStream);
            writer.Write(data);

            //flush - metoda, która wymusza zapisanie wszystkich danych z bufora do strumienia docelowego. Jest to ważne, ponieważ strumienie często używają buforowania, aby poprawić wydajność operacji we/wy. Wywołanie Flush() zapewnia, że wszystkie dane zostaną zapisane do pliku, nawet jeśli bufor nie jest pełny.
            fileStream.Flush();

            //jeśli nie używamy using, musimy ręcznie wywołać metodę Dispose() na obiekcie strumienia, aby zwolnić zasoby. Jeśli tego nie zrobimy, może dojść do wycieku pamięci i innych problemów związanych z zarządzaniem zasobami. Dlatego zaleca się korzystanie z using, aby zapewnić poprawne zarządzanie zasobami i uniknąć potencjalnych problemów.
            //fileStream.Dispose();
        }

        private void ToXml()
        {
            var items = service.ReadAll().Cast<T>().ToList();

            XmlSerializer serializer = new XmlSerializer(items.GetType());

            using MemoryStream memoryStream = new MemoryStream();
            serializer.Serialize(memoryStream, items);

            string xml = Encoding.UTF8.GetString(memoryStream.ToArray());
            Console.WriteLine(xml);
            SaveToFile(xml, "items.xml");

        }

        private void ToJson()
        {
            var items = service.ReadAll().Cast<T>();

            

               string json = JsonSerializer.Serialize(items, _options);
            Console.WriteLine(json);
            SaveToFile(json, "items.json");
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


        public static int ReadInt(string label, int @default = 0)
        {
            int value = 4;
            if (!TryReadInt(label, out value, @default))
            {
                ReadInt(label);
            }
            return value;
        }


        //worzymy własną metodę zgodnie z Try Pattern - metoda, która próbuje wykonać jakąś operację i zwraca boola informującego o sukcesie oraz wynik tej operacji przez parametr out
        public static bool TryReadInt(string label, out int result, int @default = 0)
        {
            Console.Write(label);
            string input = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(input))
            {
                result = @default;
                return true;
            }

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
