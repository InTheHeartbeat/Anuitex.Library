using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anuitex.Library.Data.Entities
{
    public class Newspaper
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Periodicity { get; set; }        
        public string Date { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        public bool AvailableToBuy => Amount > 0;
    }
}
