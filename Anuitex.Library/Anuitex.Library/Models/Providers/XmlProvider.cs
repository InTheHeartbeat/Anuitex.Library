using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Anuitex.Library.Models.Providers
{
    public class XmlRepository
    {
        public void Export<T>(List<T> entities, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

            using (FileStream fileStream = new FileStream(filePath, FileMode.CreateNew))
            {
                serializer.Serialize(fileStream, entities);
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
