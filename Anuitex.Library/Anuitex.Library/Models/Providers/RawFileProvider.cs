using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anuitex.Library.Data.Entities;

namespace Anuitex.Library.Models.Providers
{
    public class RawFileRepository
    {
        public void Export<T>(List<T> data, string path)
        {
            if (typeof(T) == typeof(Book))
            {
                ExportBooks(data as List<Book>, path);
            }
            if (typeof(T) == typeof(Journal))
            {
                ExportJournals(data as List<Journal>, path);
            }
            if (typeof(T) == typeof(Newspaper))
            {
                ExportNewspapers(data as List<Newspaper>, path);
            }
        }
        private void ExportNewspapers(List<Newspaper> newspapers, string path)
        {
            using (StreamWriter writer = new StreamWriter(path, false, Encoding.Default))
            {
                writer.WriteLine("Journals");

                foreach (Newspaper newspaper in newspapers)
                {
                    writer.WriteLine(newspaper.Id);
                    writer.WriteLine(newspaper.Title);
                    writer.WriteLine(newspaper.Periodicity);                    
                    writer.WriteLine(newspaper.Date);
                    writer.WriteLine(newspaper.Amount);
                    writer.WriteLine(newspaper.Price);
                }
            }
        }
        private void ExportJournals(List<Journal> journals, string path)
        {
            using (StreamWriter writer = new StreamWriter(path, false, Encoding.Default))
            {
                writer.WriteLine("Journals");                                

                foreach (Journal journal in journals)
                {
                    writer.WriteLine(journal.Id);
                    writer.WriteLine(journal.Title);
                    writer.WriteLine(journal.Periodicity);
                    writer.WriteLine(journal.Subjects);
                    writer.WriteLine(journal.Date);                    
                    writer.WriteLine(journal.Amount);
                    writer.WriteLine(journal.Price);
                }
            }
        }
        private void ExportBooks(List<Book> books, string path)
        {
            using (StreamWriter writer = new StreamWriter(path, false, Encoding.Default))
            {
                writer.WriteLine("Books");                                

                foreach (Book book in books)
                {
                    writer.WriteLine(book.Id);
                    writer.WriteLine(book.Title);
                    writer.WriteLine(book.Year);
                    writer.WriteLine(book.Pages);
                    writer.WriteLine(book.Author);
                    writer.WriteLine(book.Genre);
                    writer.WriteLine(book.Amount);
                    writer.WriteLine(book.Price);
                }
            }
        }

        public List<T> Import<T>(string path)
        {
            if (typeof(T) == typeof(Book))
            {
                return ImportBooks(path) as List<T>;
            }
            if (typeof(T) == typeof(Journal))
            {
                return ImportJournals(path) as List<T>;
            }
            if (typeof(T) == typeof(Newspaper))
            {
                return ImportNewspapers(path) as List<T>;
            }
            return null;
        }

        private List<Book> ImportBooks(string path)
        {
            List<Book> result = new List<Book>();
            using (StreamReader streamReader = new StreamReader(path, Encoding.Default))
            {
                string[] data = streamReader.ReadToEnd().Replace("\r","").Split('\n');
                if(data[0] != "Books") throw new Exception("Incorrect file");
                for (var i = 0; i + 8 < data.Length; i+=8)
                {                    
                    result.Add(new Book()
                    {
                        Id = int.Parse(data[i+1]),
                        Title = data[i+2],
                        Year = int.Parse(data[i+3]),
                        Pages = int.Parse(data[i+4]),
                        Author = data[i+5],
                        Genre = data[i+6],
                        Amount = int.Parse(data[i+7]),
                        Price = double.Parse(data[i+8])
                    });
                }
            }
            return result;
        }

        private List<Journal> ImportJournals(string path)
        {
            List<Journal> result = new List<Journal>();
            using (StreamReader streamReader = new StreamReader(path))
            {
                string[] data = streamReader.ReadToEnd().Split('\n');
                if (data[0] != "Journals") throw new Exception("Incorrect file");
                for (var i = 0; i+7 < data.Length; i += 7)
                {
                    result.Add(new Journal()
                    {
                        Id = int.Parse(data[i + 1]),
                        Title = data[i + 2],
                        Periodicity = data[i + 3],
                        Subjects = data[i + 4],
                        Date = data[i + 5],                       
                        Amount = int.Parse(data[i + 6]),
                        Price = double.Parse(data[i + 7])
                    });
                }
            }
            return result;
        }

        private List<Newspaper> ImportNewspapers(string path)
        {
            List<Newspaper> result = new List<Newspaper>();
            using (StreamReader streamReader = new StreamReader(path))
            {
                string[] data = streamReader.ReadToEnd().Split('\n');
                if (data[0] != "Newspapers") throw new Exception("Incorrect file");
                for (var i = 0; i+6 < data.Length; i += 6)
                {
                    result.Add(new Newspaper()
                    {
                        Id = int.Parse(data[i + 1]),
                        Title = data[i + 2],
                        Periodicity = data[i + 3],                        
                        Date = data[i + 4],
                        Amount = int.Parse(data[i + 5]),
                        Price = double.Parse(data[i + 6])
                    });
                }
            }
            return result;
        }
    }
}
