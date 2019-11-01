using System.IO;
using System.Xml.Serialization;

namespace Lab5
{
    public class XmlSerializator: Serializator
    {
        public void Serialize(string path, Triangle triangle)
        {
            Stream stream = File.Create(path);
            XmlSerializer xml = new XmlSerializer(typeof(Triangle));
            xml.Serialize(stream, triangle);
        }

        public Triangle Deserialize(string path)
        {
            Stream stream = File.OpenRead(path);
            XmlSerializer xml = new XmlSerializer(typeof(Triangle));
            return (Triangle) xml.Deserialize(stream);
        }
    }
}