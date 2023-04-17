using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace csharp_gestore_eventi
{
    internal class Event
    {
        private string title;
        private DateTime date;
        public string Title
        {
            get { return title; }
            set {
                title = value;
                while (String.IsNullOrEmpty(title))
                {
                    Console.Write("Insert a valid name: ");
                    string name = Console.ReadLine();
                    title = name;
                    if (String.IsNullOrEmpty(title))
                    {
                        new ExceptionTitle();
                    }
                }
            }
        }
        public DateTime Date 
        {
            get {

                return date;
            }
            set {
                date = value;
                while (DateTime.Compare( date,DateTime.Now) <= 0)
                {

                    string? dateInserted = Console.ReadLine();
                    DateTime date;
                    DateTime.TryParse(dateInserted, out date);
                    this.date = date;



                    if (DateTime.Compare(date, date) < 0)
                    {
                        new ExceptionDate();
                    }
                }
                
                
            }
        }
        public int MaxSeats { get; }
        public int ReservedSeats { get; private set; }
        

        public Event(string title, DateTime date, int maxSeats, int reservedSeats=0)
        {
            Title = title;
            Date = date;
            MaxSeats = maxSeats;
            ReservedSeats = reservedSeats;
        }

        public int BookSeats(int seats)
        {
            int reserved=0;
            reserved += seats; 
            while (seats<0 || seats > (MaxSeats - ReservedSeats))
            {

                seats = Convert.ToInt32(Console.ReadLine());
                

                if (seats < 0 || seats > (MaxSeats - ReservedSeats))
                {
                    new ExceptionSeats();
                }
                else
                {
                    reserved = seats;
                }


            }
            return this.ReservedSeats =  reserved;
        }
        
        public int CancelSeats(int seatsToRemove)
        {
            this.ReservedSeats = this.ReservedSeats - seatsToRemove;
            return this.ReservedSeats ; 

        }

        public override string ToString()
        {
            return Date.ToString("dd/MM/yyyy")+ " - " + Title;
        }
    }
}
