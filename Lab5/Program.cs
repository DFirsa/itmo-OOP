using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Triangle triangle = new Triangle(new Point(0, 0), new Point(0, 10), new Point(10, 0));

            string binPath = "SerializedTriangle.bin";
            BinSerializator bin = new BinSerializator();
            bin.Serialize(binPath, triangle);
            Console.WriteLine(bin.Deserialize(binPath).ToString());

            string xmlPath = "SerializedXml.xml";
            XmlSerializator xml = new XmlSerializator();
            xml.Serialize(xmlPath, triangle);
            Console.WriteLine(xml.Deserialize(xmlPath).ToString());
        }
    }
}