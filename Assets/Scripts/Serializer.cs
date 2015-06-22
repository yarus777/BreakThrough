using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets.Scripts
{
    public class Serializer
    {
        
        public void Serialize(object obj, string path)
        {
            var serializer = new XmlSerializer(obj.GetType());
            using (var writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, obj);
            }
        }

        public T Deserialize<T>(string path)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StreamReader(path))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
