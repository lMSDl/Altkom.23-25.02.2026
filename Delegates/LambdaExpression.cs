using System;
using System.Collections.Generic;
using System.Text;

namespace Delegates
{
    internal class LambdaExpression
    {
        Func<int, int, int> Calculator { get; set; }
        Func<string> SomeFunc { get; set; }
        Action<int> SomeAction { get; set; }
        Action AnotherAction { get; set; }

        //wyrażenie lambda - to skrót do delegata, który pozwala na tworzenie anonimowych funkcji, które mogą być przypisane do delegatów lub wywoływane bezpośrednio. Składnia wyrażenia lambda jest następująca: (parametry) => { ciało funkcji }. Wyrażenia lambda są często używane w LINQ i innych kontekstach, gdzie potrzebujemy przekazać funkcję jako argument do innej metody.
        //<opcjonalny parametr> <operator> <ciało>
        //(a, b) => {}
        public void Test()
        {
            Calculator = Calc;

            //przypisanie metody anonimej do delegata - metoda anonimowa to funkcja, która nie ma nazwy i jest definiowana bezpośrednio w miejscu, gdzie jest używana. Można ją przypisać do delegata lub wywołać bezpośrednio. Składnia metody anonimowej jest następująca: delegate (parametry) { ciało funkcji }. Metody anonimowe są często używane w kontekstach, gdzie potrzebujemy przekazać funkcję jako argument do innej metody, ale nie chcemy definiować osobnej metody o nazwie.

            Calculator = delegate (int a, int b) { return a - b; };
            //lambda expression - wyrażenie lambda to skrót do delegata, który pozwala na tworzenie anonimowych funkcji, które mogą być przypisane do delegatów lub wywoływane bezpośrednio. Składnia wyrażenia lambda jest następująca: (parametry) => { ciało funkcji }. Wyrażenia lambda są często używane w LINQ i innych kontekstach, gdzie potrzebujemy przekazać funkcję jako argument do innej metody.
            Calculator = (int a, int b) => { return a - b; };
            Calculator = (a, b) => { return a - b; };
            //najprostsza forma - jeśli ciało funkcji składa się z jednej instrukcji, można pominąć nawiasy klamrowe i słowo kluczowe return, a wynik tej instrukcji zostanie automatycznie zwrócony jako wynik wyrażenia lambda.
            Calculator = (a, b) => a - b;

            SomeFunc = delegate () { return "Hello"; };
            SomeFunc = () => { return "Hello"; };
            SomeFunc = () => "Hello";

            SomeAction = delegate (int a) { Console.WriteLine(a); };
            SomeAction = (int a) => { Console.WriteLine(a); };
            //jeśli jest jeden parametr, można pominąć nawiasy wokół parametru
            SomeAction = a => Console.WriteLine(a);
            
            AnotherAction = delegate () { Console.WriteLine("Hello"); };
            AnotherAction = () => { Console.WriteLine("Hello");  };
            AnotherAction = () => Console.WriteLine("Hello");

        }


        int Calc(int a, int b)
        {
            return a + b;
        }
    }
}
