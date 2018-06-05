using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static String filename = "file.txt";
        static void Main(string[] args)
        {
            FileStream fileStream = File.OpenRead(filename);
            SerializableFile.SerializableFile file = new SerializableFile.SerializableFile(filename, File.ReadAllBytes(filename));

            try
            {
                Client client = new Client("127.0.0.1", 30000);
                Console.WriteLine("Sending data");
                client.SendData(file);
                Console.WriteLine("Close client");
                client.Dispose();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
