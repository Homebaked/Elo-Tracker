using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Elo_Tracker.Utilities
{
    public static class Serializer<T>
    {
        public static void Save(IEnumerable<T> things, string filePath)
        {
            FileStream outFile = File.Create(filePath);
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            formatter.Serialize(outFile, things);
        }

        public static List<T> Load(string filePath)
        {
            List<T> things = new List<T>();
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            FileStream inFile = new FileStream(filePath, FileMode.Open);
            byte[] buffer = new byte[inFile.Length];
            inFile.Read(buffer, 0, (int)inFile.Length);
            MemoryStream stream = new MemoryStream(buffer);
            return (List<T>)formatter.Deserialize(stream);
        }
    }
}
