using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Anuitex.Library.Data.Entities;
using Anuitex.Library.Data.Interfaces;

namespace Anuitex.Library.Models.Providers
{
    public class XmlRepository
    {
        public void Export(List<ILibraryEntity> entities, string filePath)
        {
            XmlSerializer serializer = null;
            if (entities.First() is Book)
            {
                serializer = new XmlSerializer(typeof(List<Book>));
                using (FileStream fileStream = new FileStream(filePath, FileMode.CreateNew))
                {
                    serializer.Serialize(fileStream, entities.Cast<Book>());
                }
            }
            if (entities.First() is Journal)
            {
                serializer = new XmlSerializer(typeof(List<Journal>));
                using (FileStream fileStream = new FileStream(filePath, FileMode.CreateNew))
                {
                    serializer.Serialize(fileStream, entities.Cast<Journal>().ToList());
                }
            }
            if (entities.First() is Newspaper)
            {
                serializer = new XmlSerializer(typeof(List<Newspaper>));
                using (FileStream fileStream = new FileStream(filePath, FileMode.CreateNew))
                {
                    serializer.Serialize(fileStream, entities.Cast<Newspaper>());
                }
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
