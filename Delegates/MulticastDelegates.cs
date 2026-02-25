namespace Delegates
{
    internal class MulticastDelegates
    {
        delegate void MulticastDelegate(string @string);

        void Message1(string @string) { Console.WriteLine("Message1: " + @string); }
        void Message2(string @string) { Console.WriteLine("Message2: " + @string); }
        void Message3(string @string) { Console.WriteLine("Message3: " + @string); }

        public void Test()
        {
            MulticastDelegate multicastDelegate = null;

            //+= - dodaje metodę do listy wywołań delegata
            multicastDelegate += Message1;
            multicastDelegate += Message2;
            multicastDelegate += Message3;
            multicastDelegate += Console.WriteLine;

            multicastDelegate.Invoke("Hello!");

            //-= - usuwa metodę z listy wywołań delegata
            multicastDelegate -= Message2;
            multicastDelegate.Invoke("Hello again!");

            //drugie wywołanie -= - usunięcie tej samej metody z listy wywołań delegata nie spowoduje żadnych zmian, ponieważ metoda została już usunięta
            multicastDelegate -= Message2;
            multicastDelegate.Invoke("Hello again again!");

            //przypisanie delegata do konkretnej metody - zastępuje listę wywołań delegata tylko jedną metodą
            multicastDelegate = Message2;
            multicastDelegate.Invoke("Hello again again again!");

            //przypisanie delegata do null - usunięcie wszystkich metod z listy wywołań delegata
            multicastDelegate = null;
            multicastDelegate?.Invoke("");
        }
    }
}
