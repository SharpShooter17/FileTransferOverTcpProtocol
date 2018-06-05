using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SerializableFile
{
    public class Serialize
    {
        public static SerializableFile readStream(Stream stream)
        {
            return (SerializableFile)new BinaryFormatter().Deserialize(stream);
        }

        public static void writeToStream(Stream stream, SerializableFile file)
        {
            new BinaryFormatter().Serialize(stream, file);
        }
    }
}
