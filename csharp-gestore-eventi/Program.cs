using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.Write("Insert your event's program name : ");
            string? nameProgram = Console.ReadLine();
            while (String.IsNullOrEmpty(nameProgram))
            {
                new ExceptionTitle();
                nameProgram = Console.ReadLine();
            }
            Console.Write("How much events do you want to add? : ");
            int amount =0;
            while (!int.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.WriteLine("Insert a valid number");
            }

            int index = 0;
            EventProgram eventProgram = new EventProgram(nameProgram);
            Console.WriteLine($"=======================================================================");
            while (amount != index)
            {
                Console.Write($"Insert a Event{index + 1}'s name: ");
                string? name = Console.ReadLine();
                while (String.IsNullOrEmpty(name))
                {
                    new ExceptionTitle();
                    name = Console.ReadLine();
                }


                Console.Write($"Insert a Event{index + 1}'s Date (dd/mm/yyyy): ");
                string? date = Console.ReadLine();
                DateTime dateToInsert;
                DateTime.TryParse(date, out dateToInsert);
                while (DateTime.Compare(dateToInsert, DateTime.Now) < 0)
                {
                    new ExceptionDate();
                    date = Console.ReadLine();
                    DateTime.TryParse(date, out dateToInsert);

                }

                Console.Write("How much seats the event has?: ");
                int maxSeats = 0;
                while (!int.TryParse(Console.ReadLine(), out maxSeats) || maxSeats <= 0)
                {
                    Console.WriteLine("Insert a valid number");
                }



                Event event1 = new Event(name, dateToInsert, maxSeats);

                Console.Write("How much seats do you want to book?: ");
                int seats = 0;
                while (!int.TryParse(Console.ReadLine(), out seats) || seats <= 0)
                {
                    Console.WriteLine("Insert a valid number");
                }


                if (seats < 0 || seats > (event1.MaxSeats - event1.ReservedSeats))
                {
                    new ExceptionSeats();
                    event1.BookSeats(seats);
                }
                else
                {
                    event1.BookSeats(seats);
                }

                Console.WriteLine($"\nReserved seats: {event1.ReservedSeats}");
                Console.WriteLine($"Available seats: {event1.MaxSeats - event1.ReservedSeats}");



                string? answer;
                int seatsToRemove = 0;
                do
                {

                    Console.Write("Do you want to cancel some seats (y/n): ");
                    answer = Console.ReadLine();
                    if (answer != "n")
                    {
                        Console.Write("How much seats do you want to cancel ?: ");
                        while (!int.TryParse(Console.ReadLine(), out seatsToRemove) || seatsToRemove <= 0)
                        {
                            Console.WriteLine("Insert a valid number");
                        }
                        if (seatsToRemove > event1.ReservedSeats || event1.ReservedSeats == 0)
                        {
                            Console.WriteLine("Invalid Number or there isn't reserved seats");
                            continue;
                        }
                        else
                        {
                            event1.CancelSeats(seatsToRemove);
                        }

                    }
                    Console.WriteLine($"Reserved seats: {event1.ReservedSeats}");
                    Console.WriteLine($"Available seats: {event1.MaxSeats - event1.ReservedSeats}");



                    Console.WriteLine($"=======================================================================");
                } while (answer != "n");
                eventProgram.events.Add(event1);
                index++;
            }
            Console.WriteLine($"=======================================================================");
            Console.WriteLine("Do you wanna add confereces too? (y/n)");
            string? answerConf = Console.ReadLine();
            if (answerConf == "y")
            {

                Console.Write($"Insert a Conference's name: ");
                string? name = Console.ReadLine();

                Console.Write($"Insert a Conference's Date (dd/mm/yyyy): ");
                string? date = Console.ReadLine();
                DateTime dateToInsert;
                DateTime.TryParse(date, out dateToInsert);
                while (DateTime.Compare(dateToInsert, DateTime.Now) < 0)
                {
                    new ExceptionDate();
                    date = Console.ReadLine();
                    DateTime.TryParse(date, out dateToInsert);

                }

                Console.Write("How much seats the Conference has?: ");
                int maxSeats = 0;
                while (!int.TryParse(Console.ReadLine(), out maxSeats) || maxSeats <= 0)
                {
                    Console.WriteLine("Insert a valid number");
                }

                Console.Write("What's relator's name?: ");
                string? relator = Console.ReadLine();
                while (String.IsNullOrEmpty(relator))
                {
                    Console.WriteLine("Insert a valid name");
                    relator = Console.ReadLine();
                }
                Console.Write("How much is the ticket?: ");
                double price;
                while (!double.TryParse(Console.ReadLine(), out price))
                {
                    Console.WriteLine("Insert a valid name");
                }




                Conference event1 = new Conference(name, dateToInsert, maxSeats, relator, price);

                Console.Write("How much seats do you want to book?: ");
                int seats = 0;
                while (!int.TryParse(Console.ReadLine(), out seats) || seats <= 0)
                {
                    Console.WriteLine("Insert a valid number");
                }
                if (seats < 0 || seats > (event1.MaxSeats - event1.ReservedSeats))
                {
                    new ExceptionSeats();
                    event1.BookSeats(seats);
                }
                else
                {
                    event1.BookSeats(seats);
                }
                eventProgram.events.Add(event1);

                Console.WriteLine($"=======================================================================");
                Console.WriteLine($"The amount of events is: {eventProgram.NrOfEvents(eventProgram.events)}");
                Console.WriteLine($"Here's your events program: ");
            }

            Console.WriteLine($"=======================================================================");
            Console.WriteLine($"The amount of events is: {eventProgram.NrOfEvents(eventProgram.events)}");
            Console.WriteLine($"Here's your events program: ");
            eventProgram.PrintProgram(eventProgram.events);
            Console.WriteLine($"=======================================================================");
            Console.Write("Insert a Date (dd/mm/yyyy) to know which events there are today: ");
            DateTime eventTodayDate;
            DateTime.TryParse(Console.ReadLine(), out eventTodayDate);
            ArrayRecivedPrint(eventProgram.eventsFiltered(eventProgram.events, eventTodayDate));
            Console.WriteLine($"=======================================================================");

            //eventProgram.DeleteEvents(eventProgram.events);

        }
        public static void ArrayRecivedPrint(List<Event> list) {
            if (list.Count > 0)
            {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            }
            else
            {
                Console.WriteLine("No events found in that Date");
            }

        }
        
    }
}