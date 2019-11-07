using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Triangle triangle = new Triangle(new Point(0, 0), new Point(0, 10), new Point(10, 0));

            Console.WriteLine(" === Binary file === ");
            string binPath = @"..\..\SerializedTriangle.bin";
            BinSerializator bin = new BinSerializator();
            bin.Serialize(binPath, triangle);
            Console.WriteLine(bin.Deserialize(binPath).ToString());

            Console.WriteLine(" === Xml file === ");
            string xmlPath = @"..\..\SerializedXml.xml";
            XmlSerializator xml = new XmlSerializator();
            xml.Serialize(xmlPath, triangle);
            Console.WriteLine(xml.Deserialize(xmlPath).ToString());
            
            Console.WriteLine(" === Data Base === ");
            DBTriangleSaver db = new DBTriangleSaver("localhost", 3306, "StoreInfo", "root", "qoe74859");
            db.saveTriangle(triangle);
            List<Triangle> triangles = db.getTriangles();
            foreach (var tr in triangles) Console.WriteLine(tr.ToString());
        }
    }
}