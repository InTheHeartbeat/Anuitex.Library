using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anuitex.Library.Data.Interfaces
{
    public interface ILibraryEntity
    {
        int Id { get; set; }
        string Title { get; set; }
        double Price { get; set; }
        int Amount { get; set; }
    }
}
