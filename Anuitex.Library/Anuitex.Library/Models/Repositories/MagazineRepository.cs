using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anuitex.Library.Data;
using Anuitex.Library.Models.Repositories;

namespace Anuitex.Library.Models.Repositories
{
    public class JournalRepository
    {
        public IEnumerable<Journal> GetList()
        {
            return DataContext.Context.LibraryContext.Journals.AsEnumerable();
        }

        public void Add(Journal item)
        {
            DataContext.Context.LibraryContext.Journals.InsertOnSubmit(item);
        }

        public void Update(Journal newItem)
        {
            Journal old = DataContext.Context.LibraryContext.Journals.FirstOrDefault(journal => journal.Id == newItem.Id);
            old.Title = !old.Title.Equals(newItem.Title) ? newItem.Title : old.Title;
            old.Date = !old.Date.Equals(newItem.Date) ? newItem.Date : old.Date;
            old.Periodicity = !old.Periodicity.Equals(newItem.Periodicity) ? newItem.Periodicity : old.Periodicity;
            old.Subjects = !old.Subjects.Equals(newItem.Subjects) ? newItem.Subjects : old.Subjects;            
            old.Available = !old.Available.Equals(newItem.Available) ? newItem.Available : old.Available;
        }

        public void Delete(Journal journal)
        {
            DataContext.Context.LibraryContext.Journals.DeleteOnSubmit(journal);
        }

        public void SetAvailableValue(int id, bool available)
        {
            Journal journal = DataContext.Context.LibraryContext.Journals.FirstOrDefault(first => first.Id == id);

            if (journal != null)
            {
                journal.Available = available;
            }
        }

        public void Submit()
        {
            DataContext.Context.LibraryContext.SubmitChanges();
        }
    }
}
