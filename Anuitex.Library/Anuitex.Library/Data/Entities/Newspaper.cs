using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anuitex.Library.Data.Interfaces;

namespace Anuitex.Library.Data.Entities
{
    [Serializable]
    public class Newspaper : ILibraryEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Periodicity { get; set; }        
        public string Date { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        public bool AvailableToBuy => Amount > 0;

        public Newspaper()
        {
                    
        }

        public Newspaper(int id, string title, string periodicity, string date, int amount, double price)
        {
            Id = id;
            Title = title;
            Periodicity = periodicity;
            Date = date;
            Amount = amount;
            Price = price;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} {Title} {Periodicity} {Date} {Price}";
        }
    }
}
