using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anuitex.Library.Data.Entities
{
    [Serializable]
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        
        public bool AvailableToBuy => Amount > 0;

        public Book()
        {
            
        }

        public Book(int id, string title, int year, int pages, string author, string genre, int amount, double price)
        {
            Id = id;
            Title = title;
            Year = year;
            Pages = pages;
            Author = author;
            Genre = genre;
            Amount = amount;
            Price = price;
        }
    }
}
