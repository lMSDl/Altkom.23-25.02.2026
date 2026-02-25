using Delegates;

new DelegatesExample().Test();
new MulticastDelegates().Test();
new BuildInDelegates().Test();


var eventsExample = new EventsExample();

//Przypisanie delegata do konkretnej metody - zastępuje listę wywołań delegata tylko jedną metodą
//eventsExample.OddNumberDelegate = Console.WriteLine;

eventsExample.OddNumberEvent += Console.WriteLine;

//możemy przypisać i odpisać każdą funkcję do której mamy dostęp (nawet jeśli została przypięta w innym miejscu w kodzie)
//eventsExample.OddNumberEvent -= eventsExample.IncreaseCounter;

eventsExample.Test();

eventsExample.OddNumberEvent -= Console.WriteLine;

//przypisanie null do zdarzenia nie jest możliwe, ponieważ zdarzenia są specjalnym rodzajem delegatów, które mają dodatkowe zabezpieczenia, aby zapobiec bezpośredniemu przypisywaniu wartości null. Zamiast tego, aby usunąć wszystkie subskrybentów zdarzenia, można użyć operatora -= do odsubskrybowania wszystkich metod, które zostały przypisane do zdarzenia. W przypadku przypisania null do zdarzenia, kompilator zgłosi błąd, ponieważ nie jest to dozwolone.
//eventsExample.OddNumberEvent = Console.WriteLine;

new LinqExamples().Test();