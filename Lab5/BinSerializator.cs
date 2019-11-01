using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab5
{
    public class BinSerializator: Serializator
    {
        public void Serialize(string path, Triangle triangle)
        {
            Stream stream = File.Create(path);
            BinaryFormatter ser = new BinaryFormatter();
            ser.Serialize(stream, triangle);
        }

        public Triangle Deserialize(string path)
        {
            Stream stream = File.OpenRead(path);
            BinaryFormatter ser = new BinaryFormatter();
            return (Triangle)ser.Deserialize(stream);
        }
    }
}