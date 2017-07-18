using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anuitex.Library.Models.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetList();
        void Add(T item);
        void Update(T newItem);
        void Delete(T book);
        void SetAvailableValue(int id, bool available);
        void Submit();
    }
}
