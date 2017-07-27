using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anuitex.Library.Data.Interfaces;

namespace Anuitex.Library.Data.Entities
{
    [Serializable]
    public class Journal : ILibraryEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Periodicity { get; set; }
        public string Subjects { get; set; }
        public string Date { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        public bool AvailableToBuy => Amount > 0;

        public Journal()
        {
            
        }

        public Journal(int id, string title, string periodicity, string subjects, string date, int amount, double price)
        {
            Id = id;
            Title = title;
            Periodicity = periodicity;
            Subjects = subjects;
            Date = date;
            Amount = amount;
            Price = price;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} {Title} {Periodicity} {Subjects} {Date} {Price}";
        }
    }
}
