namespace Delegates
{
    //Delegaty to typy referencyjne, które reprezentują metody o określonym sygnaturze.
    //Delegaty pozwalają na przypisywanie metod do zmiennych i wywoływanie ich w sposób dynamiczny lub przekazywanie ich jako argumentów do innych metod.
    //Potocznie to wskaźniki na metody
    internal class DelegatesExample
    {
        //delegat, który może wskazywać na metody, które nie zwracają wartości i nie przyjmują żadnych parametrów
        delegate void VoidWithoutParams();
        //dlegat, który może wskazywać na metody, które nie zwracają wartości, ale przyjmują jeden parametr typu string
        delegate void VoidWithParam(string @string);
        //delegat, który może wskazywać na metody, które zwracają wartość typu bool i przyjmują dwa parametry typu int
        delegate bool BoolWithParams(int int1, int int2);

        public void Func1()
        {
            Console.WriteLine("Func1");
        }

        public void Func2(string param)
        {
            Console.WriteLine(param);
        }

        public bool Func3(int int1, int int2)
        {
            return int1 == int2;
        }

        BoolWithParams Delegate3 { get; set; }

        public void Test()
        {
            Run(Func1);

            VoidWithoutParams delegate1 = null;
            delegate1?.Invoke(); //wywołanie bezpieczne, sprawdza czy delegate1 nie jest null przed wywołaniem
            delegate1 = Func1; //przypisanie metody Func1 do delegate1
            delegate1(); //wywołanie delegate1, które teraz wskazuje na Func1

            VoidWithParam delegate2 = new VoidWithParam(Func2); //tworzenie instancji delegata delegate2, który wskazuje na metodę Func2
            delegate2.Invoke("Func2");


            Delegate3 = Func3; //przypisanie metody Func3 do właściwości Delegate3

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    bool result = Delegate3.Invoke(i, j);
                    Console.WriteLine(result);
                }


        }

        //funkcja przyjmująca jako parametr delegat VoidWithoutParams, który reprezentuje metodę bez parametrów i bez wartości zwracanej
        private void Run(VoidWithoutParams someFunction)
        {
            if(DateTime.Now.Second % 2 == 0)
                someFunction.Invoke();
        }
    }
}
