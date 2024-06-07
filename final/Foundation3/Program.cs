namespace Foundation3;
using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Anytown", "NY", "12345");
        Address address2 = new Address("456 Elm St", "Othertown", "CA", "67890");
        Address address3 = new Address("789 Oak St", "Somewhere", "TX", "54321");

        Event[] events = new Event[]
        {
            new Lecture("Interesting Topic", "Learn something new", DateTime.Now, new TimeSpan(10, 0, 0), address1, "John Doe", 50),
            new Reception("Networking Event", "Meet professionals", DateTime.Now.AddDays(1), new TimeSpan(18, 30, 0), address2, "rsvp@example.com"),
            new OutdoorGathering("Picnic in the Park", "Enjoy nature", DateTime.Now.AddDays(2), new TimeSpan(12, 0, 0), address3, "Sunny")
        };

        foreach (Event e in events)
        {
            Console.WriteLine("Standard Details:");
            Console.WriteLine(e.GetStandardDetails());
            Console.WriteLine();

            Console.WriteLine("Full Details:");
            Console.WriteLine(e.GetFullDetails());
            Console.WriteLine();

            Console.WriteLine("Short Description:");
            Console.WriteLine(e.GetShortDescription());
            Console.WriteLine();

            Console.WriteLine("-----------------------------------------");
        }
    }
}
