using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class EventProgram
    {
       public string Title { get; set; }
       public List<Event> events ;

        public EventProgram(string title)
        {
           this.Title = title;
            events = new List<Event>();
        }

        public static void PrintEventList(List<Event> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        public void AddEvent(Event eventNr)
        {
            events.Add(eventNr);
        }

        public List<Event> eventsFiltered(List<Event> list,DateTime dateInserted)
        {
            List<Event> filteredList = new List<Event>();
            for (int i = 0; i < list.Count; i++)
            {
                if (DateTime.Compare(list[i].Date, dateInserted) == 0)
                {
                    filteredList.Add(list[i]);
                }
            }
            return filteredList;

        }
        public int NrOfEvents(List<Event> list)
        {
            return list.Count;
        }
        public void DeleteEvents(List<Event> list)
        {
            list.Clear();
        }
        public void PrintProgram(List<Event>list)
        {
            Console.WriteLine($"{this.Title}: \n");
            foreach(var item in list) {
                Console.WriteLine($"\t {item}");               
            }
        }
    }
}
