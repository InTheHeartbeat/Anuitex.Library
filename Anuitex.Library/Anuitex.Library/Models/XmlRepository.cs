using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Anuitex.Library.Data.Entities;

namespace Anuitex.Library.Models
{
    public class XmlRepository
    {
        public void Export<T>(List<T> books, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

            using (FileStream fileStream = new FileStream(filePath, FileMode.CreateNew))
            {
                serializer.Serialize(fileStream, books);
            }
        }

        public List<T> Import<T>(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            List<T> result;

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                result = (List<T>) serializer.Deserialize(fileStream);
            }
            return result;
        }
    }
}
