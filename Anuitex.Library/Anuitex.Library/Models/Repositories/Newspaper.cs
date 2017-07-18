using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anuitex.Library.Data;
using Anuitex.Library.Models.Repositories.Interfaces;

namespace Anuitex.Library.Models.Repositories
{
    public class NewspaperRepository : IRepository<Newspaper>
    {
        public IEnumerable<Newspaper> GetList()
        {
            return DataContext.Context.LibraryContext.Newspapers.AsEnumerable();
        }

        public void Add(Newspaper item)
        {
            DataContext.Context.LibraryContext.Newspapers.InsertOnSubmit(item);
        }

        public void Update(Newspaper newItem)
        {
            Newspaper old = DataContext.Context.LibraryContext.Newspapers.FirstOrDefault(newspaper => newspaper.Id == newItem.Id);
            old.Title = !old.Title.Equals(newItem.Title) ? newItem.Title : old.Title;
            old.Date = !old.Date.Equals(newItem.Date) ? newItem.Date : old.Date;
            old.Periodicity = !old.Periodicity.Equals(newItem.Periodicity) ? newItem.Periodicity : old.Periodicity;            
            old.Available = !old.Available.Equals(newItem.Available) ? newItem.Available : old.Available;
        }

        public void Delete(Newspaper newspaper)
        {
            DataContext.Context.LibraryContext.Newspapers.DeleteOnSubmit(newspaper);
        }

        public void SetAvailableValue(int id, bool available)
        {
            Newspaper newspaper = DataContext.Context.LibraryContext.Newspapers.FirstOrDefault(first => first.Id == id);

            if (newspaper != null)
            {
                newspaper.Available = available;
            }
        }

        public void Submit()
        {
            DataContext.Context.LibraryContext.SubmitChanges();
        }
    }
}
