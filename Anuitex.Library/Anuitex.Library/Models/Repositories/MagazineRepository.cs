using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anuitex.Library.Data;
using Anuitex.Library.Models.Repositories.Interfaces;

namespace Anuitex.Library.Models.Repositories
{
    public class MagazineRepository : IRepository<Magazine>
    {
        public IEnumerable<Magazine> GetList()
        {
            return DataContext.Context.LibraryContext.Magazines.AsEnumerable();
        }

        public void Add(Magazine item)
        {
            DataContext.Context.LibraryContext.Magazines.InsertOnSubmit(item);
        }

        public void Update(Magazine newItem)
        {
            Magazine old = DataContext.Context.LibraryContext.Magazines.FirstOrDefault(magazine => magazine.Id == newItem.Id);
            old.Title = !old.Title.Equals(newItem.Title) ? newItem.Title : old.Title;
            old.Date = !old.Date.Equals(newItem.Date) ? newItem.Date : old.Date;
            old.Periodicity = !old.Periodicity.Equals(newItem.Periodicity) ? newItem.Periodicity : old.Periodicity;
            old.Subjects = !old.Subjects.Equals(newItem.Subjects) ? newItem.Subjects : old.Subjects;            
            old.Available = !old.Available.Equals(newItem.Available) ? newItem.Available : old.Available;
        }

        public void Delete(Magazine magazine)
        {
            DataContext.Context.LibraryContext.Magazines.DeleteOnSubmit(magazine);
        }

        public void SetAvailableValue(int id, bool available)
        {
            Magazine magazine = DataContext.Context.LibraryContext.Magazines.FirstOrDefault(first => first.Id == id);

            if (magazine != null)
            {
                magazine.Available = available;
            }
        }

        public void Submit()
        {
            DataContext.Context.LibraryContext.SubmitChanges();
        }
    }
}
